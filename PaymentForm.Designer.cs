#nullable disable
namespace ADBMS_Project
{
    partial class PaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBill = new System.Windows.Forms.Label();
            this.cboBill = new System.Windows.Forms.ComboBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();

            this.lblBill.Location = new System.Drawing.Point(30, 30);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(100, 25);
            this.lblBill.Text = "Unpaid Bill:";

            this.cboBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBill.Location = new System.Drawing.Point(140, 30);
            this.cboBill.Name = "cboBill";
            this.cboBill.Size = new System.Drawing.Size(300, 25);
            this.cboBill.SelectedIndexChanged += new System.EventHandler(this.cboBill_SelectedIndexChanged);

            this.lblAmount.Location = new System.Drawing.Point(30, 70);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 25);
            this.lblAmount.Text = "Amount:";

            this.txtAmount.Location = new System.Drawing.Point(140, 70);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(150, 25);

            this.lblDate.Location = new System.Drawing.Point(30, 110);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(100, 25);
            this.lblDate.Text = "Payment Date:";

            this.txtDate.Location = new System.Drawing.Point(140, 110);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(150, 25);

            this.btnPay.Location = new System.Drawing.Point(140, 150);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(150, 35);
            this.btnPay.Text = "Process Payment";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);

            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.Location = new System.Drawing.Point(30, 200);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPayments.Size = new System.Drawing.Size(640, 250);
            this.dgvPayments.SelectionChanged += new System.EventHandler(this.dgvPayments_SelectionChanged);

            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.lblBill); this.Controls.Add(this.cboBill);
            this.Controls.Add(this.lblAmount); this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblDate); this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.dgvPayments);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Processing";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.ComboBox cboBill;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.DataGridView dgvPayments;
    }
}
