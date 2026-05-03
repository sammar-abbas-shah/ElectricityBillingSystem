#nullable disable
using System.Windows.Forms;

namespace ADBMS_Project
{
    public partial class DashboardForm : Form
    {
        private string userRole;

        public DashboardForm(string role)
        {
            userRole = role;
            InitializeComponent();
            btnUsers.Visible = (userRole == "Admin");
        }

        private void btnCustomers_Click(object sender, System.EventArgs e) => new CustomersForm().Show();
        private void btnConsumption_Click(object sender, System.EventArgs e) => new ConsumptionForm().Show();
        private void btnBills_Click(object sender, System.EventArgs e) => new BillForm().Show();
        private void btnPayments_Click(object sender, System.EventArgs e) => new PaymentForm().Show();
        private void btnReports_Click(object sender, System.EventArgs e) => new ReportsForm().Show();
        private void btnUsers_Click(object sender, System.EventArgs e) => new UsersForm().Show();
        private void btnLogout_Click(object sender, System.EventArgs e) { this.Close(); Application.Restart(); }
    }
}
