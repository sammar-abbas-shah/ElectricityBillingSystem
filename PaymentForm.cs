#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class PaymentForm : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";

        public PaymentForm()
        {
            InitializeComponent();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LoadUnpaidBills();
            LoadPayments();
        }

        private void LoadUnpaidBills()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT b.bill_id, c.name AS Customer, b.amount
                    FROM bills b JOIN customers c ON b.customer_id = c.customer_id
                    WHERE b.status = 'Unpaid'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cboBill.DisplayMember = "Customer";
                cboBill.ValueMember = "bill_id";
                cboBill.DataSource = dt;
            }
        }

        private void dgvPayments_SelectionChanged(object sender, EventArgs e) => dgvPayments.ClearSelection();

        private void cboBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBill.SelectedValue == null) return;
            if (cboBill.SelectedValue is int billId)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT amount FROM bills WHERE bill_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", billId);
                        decimal amount = (decimal)cmd.ExecuteScalar();
                        txtAmount.Text = amount.ToString("N2");
                    }
                }
            }
            else if (cboBill.SelectedItem is DataRowView drv)
            {
                txtAmount.Text = drv["amount"].ToString();
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (cboBill.SelectedValue == null) { MessageBox.Show("Select a bill to pay"); return; }
            if (!DateTime.TryParse(txtDate.Text, out DateTime payDate)) { MessageBox.Show("Invalid date"); return; }

            int billId = (int)cboBill.SelectedValue;
            decimal amountPaid = decimal.Parse(txtAmount.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO payments (bill_id, amount_paid, payment_date) VALUES (@bid, @amt, @date)", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bid", billId);
                            cmd.Parameters.AddWithValue("@amt", amountPaid);
                            cmd.Parameters.AddWithValue("@date", payDate);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE bills SET status='Paid' WHERE bill_id=@bid", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@bid", billId);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch { transaction.Rollback(); throw; }
                }
            }
            MessageBox.Show($"Payment of Rs.{amountPaid:N2} recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUnpaidBills();
            LoadPayments();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void LoadPayments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT p.payment_id, c.name AS Customer, p.amount_paid, p.payment_date
                    FROM payments p
                    JOIN bills b ON p.bill_id = b.bill_id
                    JOIN customers c ON b.customer_id = c.customer_id
                    ORDER BY p.payment_date DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPayments.DataSource = dt;
            }
        }
    }
}
