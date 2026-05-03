#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class ConsumptionForm : Form
    {
        private int selectedConsumptionId = -1;
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";

        public ConsumptionForm()
        {
            InitializeComponent();
            txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            LoadCustomers();
            LoadHistory();
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

        private void LoadHistory()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT c.consumption_id, cust.name AS Customer, c.units, c.record_date
                    FROM consumption c JOIN customers cust ON c.customer_id = cust.customer_id
                    ORDER BY c.record_date DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvHistory.DataSource = dt;
            }
        }

        private void dgvHistory_SelectionChanged(object sender, EventArgs e) => dgvHistory.ClearSelection();

        private void dgvHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedConsumptionId = Convert.ToInt32(dgvHistory.Rows[e.RowIndex].Cells["consumption_id"].Value);
                string custName = dgvHistory.Rows[e.RowIndex].Cells["Customer"].Value.ToString();
                foreach (DataRowView item in cboCustomer.Items)
                    if (item["name"].ToString() == custName) { cboCustomer.SelectedItem = item; break; }
                txtUnits.Text = dgvHistory.Rows[e.RowIndex].Cells["units"].Value.ToString();
                txtDate.Text = Convert.ToDateTime(dgvHistory.Rows[e.RowIndex].Cells["record_date"].Value).ToString("yyyy-MM-dd");
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedValue == null || string.IsNullOrWhiteSpace(txtUnits.Text))
            { MessageBox.Show("Select customer and enter units"); return; }
            if (!DateTime.TryParse(txtDate.Text, out DateTime recordDate)) { MessageBox.Show("Invalid date"); return; }
            if (!int.TryParse(txtUnits.Text, out int units) || units <= 0) { MessageBox.Show("Enter valid units"); return; }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO consumption (customer_id, units, record_date) VALUES (@cid, @u, @d)", con))
                {
                    cmd.Parameters.AddWithValue("@cid", (int)cboCustomer.SelectedValue);
                    cmd.Parameters.AddWithValue("@u", units);
                    cmd.Parameters.AddWithValue("@d", recordDate);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadHistory(); ClearFields();
            MessageBox.Show("Consumption recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedConsumptionId == -1) { MessageBox.Show("Select a record to update"); return; }
            if (!DateTime.TryParse(txtDate.Text, out DateTime recordDate)) { MessageBox.Show("Invalid date"); return; }
            if (!int.TryParse(txtUnits.Text, out int units)) { MessageBox.Show("Enter valid units"); return; }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE consumption SET units=@u, record_date=@d WHERE consumption_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@u", units);
                    cmd.Parameters.AddWithValue("@d", recordDate);
                    cmd.Parameters.AddWithValue("@id", selectedConsumptionId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadHistory(); ClearFields();
            MessageBox.Show("Consumption updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedConsumptionId == -1) { MessageBox.Show("Select a record to delete"); return; }
            if (DialogResult.Yes == MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM consumption WHERE consumption_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedConsumptionId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadHistory(); ClearFields();
                MessageBox.Show("Record deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields() { txtUnits.Text = ""; txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd"); selectedConsumptionId = -1; cboCustomer.SelectedIndex = -1; }
    }
}
