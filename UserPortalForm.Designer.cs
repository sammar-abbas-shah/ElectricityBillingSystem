#nullable disable
namespace ADBMS_Project
{
    partial class UserPortalForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummaryTitle = new System.Windows.Forms.Label();
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lblAmountDue = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.pnlBilling = new System.Windows.Forms.Panel();
            this.lblBillingTitle = new System.Windows.Forms.Label();
            this.dgvMonthlyBills = new System.Windows.Forms.DataGridView();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblSelectBill = new System.Windows.Forms.Label();
            this.cboUnpaidBills = new System.Windows.Forms.ComboBox();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.txtPaymentDate = new System.Windows.Forms.TextBox();
            this.btnMakePayment = new System.Windows.Forms.Button();
            this.lblPaymentHistory = new System.Windows.Forms.Label();
            this.dgvPaymentHistory = new System.Windows.Forms.DataGridView();
            this.pnlSummary.SuspendLayout();
            this.gbCustomerDetails.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.pnlBilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyBills)).BeginInit();
            this.pnlPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.SuspendLayout();

            // Nav buttons
            this.btnSummary.Location = new System.Drawing.Point(20, 30);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(150, 35);
            this.btnSummary.Text = "Account Summary";
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);

            this.btnBilling.Location = new System.Drawing.Point(20, 80);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(150, 35);
            this.btnBilling.Text = "Billing";
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);

            this.btnPayments.Location = new System.Drawing.Point(20, 130);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(150, 35);
            this.btnPayments.Text = "Make Payment";
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);

            this.btnLogout.Location = new System.Drawing.Point(20, 500);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 35);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // pnlSummary
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Location = new System.Drawing.Point(190, 20);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(680, 530);

            this.lblSummaryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(640, 30);
            this.lblSummaryTitle.Text = "ACCOUNT SUMMARY";
            this.lblSummaryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.gbCustomerDetails.Location = new System.Drawing.Point(20, 70);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(640, 120);
            this.gbCustomerDetails.Text = "Customer Details";

            this.lblCustomerName.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(600, 25);
            this.lblCustomerName.Text = "Name: ";

            this.lblCustomerAddress.Location = new System.Drawing.Point(20, 60);
            this.lblCustomerAddress.Name = "lblCustomerAddress";
            this.lblCustomerAddress.Size = new System.Drawing.Size(600, 25);
            this.lblCustomerAddress.Text = "Address: ";

            this.lblCustomerId.Location = new System.Drawing.Point(20, 90);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(600, 25);
            this.lblCustomerId.Text = "Customer ID: ";

            this.gbCustomerDetails.Controls.Add(this.lblCustomerName);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerAddress);
            this.gbCustomerDetails.Controls.Add(this.lblCustomerId);

            this.gbStatus.Location = new System.Drawing.Point(20, 210);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(640, 100);
            this.gbStatus.Text = "Current Status";

            this.lblAmountDue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAmountDue.Location = new System.Drawing.Point(20, 30);
            this.lblAmountDue.Name = "lblAmountDue";
            this.lblAmountDue.Size = new System.Drawing.Size(600, 25);
            this.lblAmountDue.Text = "Amount Due: ";

            this.lblDueDate.Location = new System.Drawing.Point(20, 60);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(600, 25);
            this.lblDueDate.Text = "Due Date: ";

            this.gbStatus.Controls.Add(this.lblAmountDue);
            this.gbStatus.Controls.Add(this.lblDueDate);
            this.pnlSummary.Controls.Add(this.lblSummaryTitle);
            this.pnlSummary.Controls.Add(this.gbCustomerDetails);
            this.pnlSummary.Controls.Add(this.gbStatus);

            // pnlBilling
            this.pnlBilling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBilling.Location = new System.Drawing.Point(190, 20);
            this.pnlBilling.Name = "pnlBilling";
            this.pnlBilling.Size = new System.Drawing.Size(680, 530);
            this.pnlBilling.Visible = false;

            this.lblBillingTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBillingTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBillingTitle.Name = "lblBillingTitle";
            this.lblBillingTitle.Size = new System.Drawing.Size(640, 30);
            this.lblBillingTitle.Text = "MONTHLY BILLS";
            this.lblBillingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.dgvMonthlyBills.AllowUserToAddRows = false;
            this.dgvMonthlyBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMonthlyBills.Location = new System.Drawing.Point(20, 70);
            this.dgvMonthlyBills.Name = "dgvMonthlyBills";
            this.dgvMonthlyBills.ReadOnly = true;
            this.dgvMonthlyBills.RowHeadersVisible = false;
            this.dgvMonthlyBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMonthlyBills.Size = new System.Drawing.Size(640, 420);
            this.dgvMonthlyBills.SelectionChanged += new System.EventHandler(this.dgvMonthlyBills_SelectionChanged);

            this.pnlBilling.Controls.Add(this.lblBillingTitle);
            this.pnlBilling.Controls.Add(this.dgvMonthlyBills);

            // pnlPayment
            this.pnlPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPayment.Location = new System.Drawing.Point(190, 20);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(680, 530);
            this.pnlPayment.Visible = false;

            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(640, 30);
            this.lblPaymentTitle.Text = "MAKE PAYMENT";
            this.lblPaymentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSelectBill.Location = new System.Drawing.Point(50, 80);
            this.lblSelectBill.Name = "lblSelectBill";
            this.lblSelectBill.Size = new System.Drawing.Size(120, 25);
            this.lblSelectBill.Text = "Select Unpaid Bill:";

            this.cboUnpaidBills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnpaidBills.Location = new System.Drawing.Point(180, 80);
            this.cboUnpaidBills.Name = "cboUnpaidBills";
            this.cboUnpaidBills.Size = new System.Drawing.Size(300, 25);

            this.lblPayDate.Location = new System.Drawing.Point(50, 120);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(120, 25);
            this.lblPayDate.Text = "Payment Date:";

            this.txtPaymentDate.Location = new System.Drawing.Point(180, 120);
            this.txtPaymentDate.Name = "txtPaymentDate";
            this.txtPaymentDate.Size = new System.Drawing.Size(150, 25);
            this.txtPaymentDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

            this.btnMakePayment.Location = new System.Drawing.Point(180, 165);
            this.btnMakePayment.Name = "btnMakePayment";
            this.btnMakePayment.Size = new System.Drawing.Size(150, 35);
            this.btnMakePayment.Text = "Process Payment";
            this.btnMakePayment.Click += new System.EventHandler(this.btnMakePayment_Click);

            this.lblPaymentHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPaymentHistory.Location = new System.Drawing.Point(20, 220);
            this.lblPaymentHistory.Name = "lblPaymentHistory";
            this.lblPaymentHistory.Size = new System.Drawing.Size(640, 25);
            this.lblPaymentHistory.Text = "Payment History";

            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentHistory.Location = new System.Drawing.Point(20, 250);
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.ReadOnly = true;
            this.dgvPaymentHistory.RowHeadersVisible = false;
            this.dgvPaymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPaymentHistory.Size = new System.Drawing.Size(640, 250);
            this.dgvPaymentHistory.SelectionChanged += new System.EventHandler(this.dgvPaymentHistory_SelectionChanged);

            this.pnlPayment.Controls.Add(this.lblPaymentTitle);
            this.pnlPayment.Controls.Add(this.lblSelectBill);
            this.pnlPayment.Controls.Add(this.cboUnpaidBills);
            this.pnlPayment.Controls.Add(this.lblPayDate);
            this.pnlPayment.Controls.Add(this.txtPaymentDate);
            this.pnlPayment.Controls.Add(this.btnMakePayment);
            this.pnlPayment.Controls.Add(this.lblPaymentHistory);
            this.pnlPayment.Controls.Add(this.dgvPaymentHistory);

            // UserPortalForm
            this.ClientSize = new System.Drawing.Size(900, 570);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnPayments);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlBilling);
            this.Controls.Add(this.pnlPayment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserPortalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Electricity Bill System - User Portal";
            this.pnlSummary.ResumeLayout(false);
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbStatus.ResumeLayout(false);
            this.pnlBilling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyBills)).EndInit();
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummaryTitle;
        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label lblAmountDue;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Panel pnlBilling;
        private System.Windows.Forms.Label lblBillingTitle;
        private System.Windows.Forms.DataGridView dgvMonthlyBills;
        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.Label lblPaymentTitle;
        private System.Windows.Forms.Label lblSelectBill;
        private System.Windows.Forms.ComboBox cboUnpaidBills;
        private System.Windows.Forms.Label lblPayDate;
        private System.Windows.Forms.TextBox txtPaymentDate;
        private System.Windows.Forms.Button btnMakePayment;
        private System.Windows.Forms.Label lblPaymentHistory;
        private System.Windows.Forms.DataGridView dgvPaymentHistory;
    }
}
