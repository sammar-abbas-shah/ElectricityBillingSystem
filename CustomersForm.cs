#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class CustomersForm : Form
    {
        private int selectedCustomerId = -1;
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";

        public CustomersForm()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT customer_id AS 'ID', name AS 'Name', address AS 'Address', phone AS 'Phone' FROM customers ORDER BY customer_id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e) => dgvCustomers.ClearSelection();

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCustomerId = Convert.ToInt32(dgvCustomers.Rows[e.RowIndex].Cells["ID"].Value);
                txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) { MessageBox.Show("Name required"); return; }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO customers (name, address, phone) VALUES (@n, @a, @p)", con))
                {
                    cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", txtPhone.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
            LoadCustomers(); ClearFields();
            MessageBox.Show("Customer added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1) { MessageBox.Show("Select a customer"); return; }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE customers SET name=@n, address=@a, phone=@p WHERE customer_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@a", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadCustomers(); ClearFields();
            MessageBox.Show("Customer updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1) { MessageBox.Show("Select a customer"); return; }
            if (DialogResult.Yes == MessageBox.Show("Delete this customer?", "Confirm", MessageBoxButtons.YesNo))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM customers WHERE customer_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedCustomerId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadCustomers(); ClearFields();
                MessageBox.Show("Customer deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields() { txtName.Text = txtAddress.Text = txtPhone.Text = ""; selectedCustomerId = -1; }
    }
}
