#nullable disable
namespace ADBMS_Project
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnCustomerReport = new System.Windows.Forms.Button();
            this.btnPaymentReport = new System.Windows.Forms.Button();
            this.btnUnpaidBills = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            this.btnCustomerReport.Location = new System.Drawing.Point(30, 30);
            this.btnCustomerReport.Name = "btnCustomerReport";
            this.btnCustomerReport.Size = new System.Drawing.Size(150, 35);
            this.btnCustomerReport.Text = "Customer Bills";
            this.btnCustomerReport.Click += new System.EventHandler(this.btnCustomerReport_Click);

            this.btnPaymentReport.Location = new System.Drawing.Point(200, 30);
            this.btnPaymentReport.Name = "btnPaymentReport";
            this.btnPaymentReport.Size = new System.Drawing.Size(150, 35);
            this.btnPaymentReport.Text = "Payments";
            this.btnPaymentReport.Click += new System.EventHandler(this.btnPaymentReport_Click);

            this.btnUnpaidBills.Location = new System.Drawing.Point(370, 30);
            this.btnUnpaidBills.Name = "btnUnpaidBills";
            this.btnUnpaidBills.Size = new System.Drawing.Size(150, 35);
            this.btnUnpaidBills.Text = "Unpaid Bills";
            this.btnUnpaidBills.Click += new System.EventHandler(this.btnUnpaidBills_Click);

            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.Location = new System.Drawing.Point(30, 80);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersVisible = false;
            this.dgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvReport.Size = new System.Drawing.Size(730, 370);
            this.dgvReport.SelectionChanged += new System.EventHandler(this.dgvReport_SelectionChanged);

            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Controls.Add(this.btnCustomerReport);
            this.Controls.Add(this.btnPaymentReport);
            this.Controls.Add(this.btnUnpaidBills);
            this.Controls.Add(this.dgvReport);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnCustomerReport;
        private System.Windows.Forms.Button btnPaymentReport;
        private System.Windows.Forms.Button btnUnpaidBills;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}
