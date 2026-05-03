#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class BillForm : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";
        private const decimal RATE_PER_UNIT = 10;

        public BillForm()
        {
            InitializeComponent();
            LoadCustomers();
            LoadBills();
        }

        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT customer_id, name FROM customers", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboCustomer.DisplayMember = "name";
                cboCustomer.ValueMember = "customer_id";
                cboCustomer.DataSource = dt;
            }
        }

        private void dgvBills_SelectionChanged(object sender, EventArgs e) => dgvBills.ClearSelection();

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null) return;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(units), 0) FROM consumption WHERE customer_id=@cid", con))
                {
                    cmd.Parameters.AddWithValue("@cid", (int)cboCustomer.SelectedValue);
                    int totalUnits = (int)cmd.ExecuteScalar();
                    txtUnits.Text = totalUnits.ToString();
                    txtAmount.Text = (totalUnits * RATE_PER_UNIT).ToString("N2");
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null) { MessageBox.Show("Select a customer"); return; }
            int custId = (int)cboCustomer.SelectedValue;
            int units = int.Parse(txtUnits.Text);
            if (units == 0) { MessageBox.Show("No consumption records found.", "Cannot Generate", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            decimal amount = units * RATE_PER_UNIT;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM bills WHERE customer_id=@cid AND status='Unpaid'", con))
                {
                    checkCmd.Parameters.AddWithValue("@cid", custId);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                    { MessageBox.Show("Customer has an unpaid bill.", "Cannot Generate", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                }
                using (SqlCommand cmd = new SqlCommand("INSERT INTO bills (customer_id, total_units, amount, bill_date, status) VALUES (@cid, @u, @amt, @d, 'Unpaid')", con))
                {
                    cmd.Parameters.AddWithValue("@cid", custId);
                    cmd.Parameters.AddWithValue("@u", units);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@d", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadBills();
            MessageBox.Show($"Bill generated! Amount: Rs.{amount:N2}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadBills()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT b.bill_id, c.name AS Customer, b.total_units, b.amount, b.bill_date, b.status
                    FROM bills b JOIN customers c ON b.customer_id = c.customer_id ORDER BY b.bill_date DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBills.DataSource = dt;
            }
        }
    }
}
