#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class UserPortalForm : Form
    {
        private string username;
        private int customerId;
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";

        public UserPortalForm(string user, int custId)
        {
            username = user;
            customerId = custId;
            InitializeComponent();
            this.Text = $"Electricity Bill System - Welcome {username}";
            LoadAccountSummary();
        }

        private void dgvMonthlyBills_SelectionChanged(object sender, EventArgs e) => dgvMonthlyBills.ClearSelection();
        private void dgvPaymentHistory_SelectionChanged(object sender, EventArgs e) => dgvPaymentHistory.ClearSelection();

        private void btnSummary_Click(object sender, EventArgs e) { ShowPanel(pnlSummary); LoadAccountSummary(); }
        private void btnBilling_Click(object sender, EventArgs e) { ShowPanel(pnlBilling); LoadBillingData(); }
        private void btnPayments_Click(object sender, EventArgs e) { ShowPanel(pnlPayment); LoadUnpaidBills(); LoadPaymentHistory(); }
        private void btnLogout_Click(object sender, EventArgs e) { this.Close(); Application.Restart(); }

        private void ShowPanel(Panel panel)
        {
            pnlSummary.Visible = false;
            pnlBilling.Visible = false;
            pnlPayment.Visible = false;
            panel.Visible = true;
        }

        private void LoadAccountSummary()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT name, address FROM customers WHERE customer_id = @cid", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", customerId);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                lblCustomerName.Text = $"Name: {r["name"]}";
                                lblCustomerAddress.Text = $"Address: {r["address"]}";
                                lblCustomerId.Text = $"Customer ID: {customerId}";
                            }
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 amount, bill_date FROM bills WHERE customer_id=@cid AND status='Unpaid' ORDER BY bill_date DESC", con))
                    {
                        cmd.Parameters.AddWithValue("@cid", customerId);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                lblAmountDue.Text = $"Amount Due: Rs. {r.GetDecimal(0):N2}";
                                lblDueDate.Text = $"Due Date: {r.GetDateTime(1).AddDays(30):MMMM dd, yyyy}";
                            }
                            else
                            {
                                lblAmountDue.Text = "Amount Due: Rs. 0.00";
                                lblDueDate.Text = "Due Date: No pending bills";
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadBillingData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT FORMAT(bill_date,'MMMM yyyy') AS 'Month',
                        total_units AS 'Units Used', amount AS 'Total Cost (Rs.)', status AS 'Status'
                        FROM bills WHERE customer_id=@cid ORDER BY bill_date DESC", con);
                    da.SelectCommand.Parameters.AddWithValue("@cid", customerId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvMonthlyBills.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadUnpaidBills()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT bill_id,
                        'Bill #' + CAST(bill_id AS VARCHAR) + ' - Rs. ' + CAST(amount AS VARCHAR) AS DisplayText
                        FROM bills WHERE customer_id=@cid AND status='Unpaid'", con);
                    da.SelectCommand.Parameters.AddWithValue("@cid", customerId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cboUnpaidBills.DisplayMember = "DisplayText";
                    cboUnpaidBills.ValueMember = "bill_id";
                    cboUnpaidBills.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            if (cboUnpaidBills.SelectedValue == null) { MessageBox.Show("Please select a bill to pay.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!DateTime.TryParse(txtPaymentDate.Text, out DateTime payDate)) { MessageBox.Show("Invalid date format.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            int billId = (int)cboUnpaidBills.SelectedValue;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (var tx = con.BeginTransaction())
                    {
                        decimal amountPaid;
                        using (SqlCommand cmd = new SqlCommand("SELECT amount FROM bills WHERE bill_id=@bid", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@bid", billId);
                            amountPaid = (decimal)cmd.ExecuteScalar();
                        }
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO payments (bill_id, amount_paid, payment_date) VALUES (@bid, @amt, @date)", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@bid", billId);
                            cmd.Parameters.AddWithValue("@amt", amountPaid);
                            cmd.Parameters.AddWithValue("@date", payDate);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("UPDATE bills SET status='Paid' WHERE bill_id=@bid", con, tx))
                        {
                            cmd.Parameters.AddWithValue("@bid", billId);
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                }
                MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUnpaidBills(); LoadPaymentHistory(); LoadAccountSummary();
                txtPaymentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Payment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadPaymentHistory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(@"SELECT p.payment_id AS 'Payment ID',
                        p.amount_paid AS 'Amount Paid (Rs.)', p.payment_date AS 'Payment Date'
                        FROM payments p JOIN bills b ON p.bill_id = b.bill_id
                        WHERE b.customer_id=@cid ORDER BY p.payment_date DESC", con);
                    da.SelectCommand.Parameters.AddWithValue("@cid", customerId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPaymentHistory.DataSource = dt;
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
