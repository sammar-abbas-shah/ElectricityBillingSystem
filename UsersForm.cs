#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class UsersForm : Form
    {
        private int selectedUserId = -1;
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";

        public UsersForm()
        {
            InitializeComponent();
            cboRole.Items.AddRange(new object[] { "Admin", "User" });
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT user_id, username, role FROM users ORDER BY user_id", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsers.DataSource = dt;
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e) => dgvUsers.ClearSelection();

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedUserId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["user_id"].Value);
                txtUsername.Text = dgvUsers.Rows[e.RowIndex].Cells["username"].Value.ToString();
                cboRole.Text = dgvUsers.Rows[e.RowIndex].Cells["role"].Value.ToString();
                txtPassword.Text = "";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            { MessageBox.Show("Username and Password required"); return; }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password, role) VALUES (@u, @p, @r)", con))
                {
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@r", cboRole.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                }
            }
            LoadUsers(); ClearFields();
            MessageBox.Show("User added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) { MessageBox.Show("Select a user to update"); return; }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string q = "UPDATE users SET username=@u, role=@r";
                if (!string.IsNullOrWhiteSpace(txtPassword.Text)) q += ", password=@p";
                q += " WHERE user_id=@id";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@r", cboRole.SelectedItem.ToString());
                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", selectedUserId);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadUsers(); ClearFields();
            MessageBox.Show("User updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) { MessageBox.Show("Select a user to delete"); return; }
            if (DialogResult.Yes == MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE user_id=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadUsers(); ClearFields();
                MessageBox.Show("User deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ClearFields() { txtUsername.Text = txtPassword.Text = ""; cboRole.SelectedIndex = -1; selectedUserId = -1; }
    }
}
