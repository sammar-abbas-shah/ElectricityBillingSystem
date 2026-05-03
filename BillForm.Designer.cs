#nullable disable
namespace ADBMS_Project
{
    partial class BillForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.dgvBills = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).BeginInit();
            this.SuspendLayout();

            this.lblCustomer.Location = new System.Drawing.Point(30, 30);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 25);
            this.lblCustomer.Text = "Customer:";

            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.Location = new System.Drawing.Point(140, 30);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(200, 25);
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);

            this.lblUnits.Location = new System.Drawing.Point(30, 70);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(100, 25);
            this.lblUnits.Text = "Total Units:";

            this.txtUnits.Location = new System.Drawing.Point(140, 70);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.ReadOnly = true;
            this.txtUnits.Size = new System.Drawing.Size(150, 25);

            this.lblAmount.Location = new System.Drawing.Point(30, 110);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(100, 25);
            this.lblAmount.Text = "Amount (Rs):";

            this.txtAmount.Location = new System.Drawing.Point(140, 110);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(150, 25);

            this.btnGenerate.Location = new System.Drawing.Point(140, 150);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 35);
            this.btnGenerate.Text = "Generate Bill";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);

            this.dgvBills.AllowUserToAddRows = false;
            this.dgvBills.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBills.Location = new System.Drawing.Point(30, 200);
            this.dgvBills.Name = "dgvBills";
            this.dgvBills.ReadOnly = true;
            this.dgvBills.RowHeadersVisible = false;
            this.dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBills.Size = new System.Drawing.Size(640, 250);
            this.dgvBills.SelectionChanged += new System.EventHandler(this.dgvBills_SelectionChanged);

            this.ClientSize = new System.Drawing.Size(700, 480);
            this.Controls.Add(this.lblCustomer); this.Controls.Add(this.cboCustomer);
            this.Controls.Add(this.lblUnits); this.Controls.Add(this.txtUnits);
            this.Controls.Add(this.lblAmount); this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.dgvBills);
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Generation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView dgvBills;
    }
}
