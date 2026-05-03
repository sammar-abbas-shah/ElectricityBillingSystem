#nullable disable
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class ReportsForm : Form
    {
        private readonly string connectionString = "Data Source=DESKTOP-TDLOT1L\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;TrustServerCertificate=True;";

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void dgvReport_SelectionChanged(object sender, EventArgs e) => dgvReport.ClearSelection();

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT c.name AS Customer, b.total_units, b.amount, b.bill_date, b.status
                    FROM customers c JOIN bills b ON c.customer_id = b.customer_id
                    ORDER BY c.name, b.bill_date", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReport.DataSource = dt;
            }
        }

        private void btnPaymentReport_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT c.name AS Customer, p.amount_paid, p.payment_date
                    FROM payments p
                    JOIN bills b ON p.bill_id = b.bill_id
                    JOIN customers c ON b.customer_id = c.customer_id
                    ORDER BY p.payment_date DESC", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReport.DataSource = dt;
            }
        }

        private void btnUnpaidBills_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT c.name AS Customer, b.total_units, b.amount, b.bill_date
                    FROM bills b JOIN customers c ON b.customer_id = c.customer_id
                    WHERE b.status = 'Unpaid'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReport.DataSource = dt;
            }
        }
    }
}
