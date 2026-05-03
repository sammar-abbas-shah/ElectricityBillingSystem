#nullable disable
namespace ADBMS_Project
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnConsumption = new System.Windows.Forms.Button();
            this.btnBills = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(320, 30);
            this.lblTitle.Text = "Admin Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.btnCustomers.Location = new System.Drawing.Point(50, 60);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(280, 40);
            this.btnCustomers.Text = "Manage Customers";
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);

            this.btnConsumption.Location = new System.Drawing.Point(50, 115);
            this.btnConsumption.Name = "btnConsumption";
            this.btnConsumption.Size = new System.Drawing.Size(280, 40);
            this.btnConsumption.Text = "Manage Consumption";
            this.btnConsumption.Click += new System.EventHandler(this.btnConsumption_Click);

            this.btnBills.Location = new System.Drawing.Point(50, 170);
            this.btnBills.Name = "btnBills";
            this.btnBills.Size = new System.Drawing.Size(280, 40);
            this.btnBills.Text = "Generate Bills";
            this.btnBills.Click += new System.EventHandler(this.btnBills_Click);

            this.btnPayments.Location = new System.Drawing.Point(50, 225);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(280, 40);
            this.btnPayments.Text = "Payments";
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);

            this.btnReports.Location = new System.Drawing.Point(50, 280);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(280, 40);
            this.btnReports.Text = "Reports";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            this.btnUsers.Location = new System.Drawing.Point(50, 335);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(280, 40);
            this.btnUsers.Text = "Manage Users";
            this.btnUsers.Visible = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);

            this.btnLogout.Location = new System.Drawing.Point(270, 410);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 30);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.ClientSize = new System.Drawing.Size(390, 460);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnConsumption);
            this.Controls.Add(this.btnBills);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electricity Bill System - Dashboard";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnConsumption;
        private System.Windows.Forms.Button btnBills;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnLogout;
    }
}
