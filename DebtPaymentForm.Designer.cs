using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{
    partial class DebtPaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblDebt;
        private ComboBox cmbDebts;
        private Label lblPaymentAmount;
        private TextBox txtPaymentAmount;
        private Label lblPaymentDate;
        private DateTimePicker dtpPaymentDate;
        private Label lblAfterPayment;
        private Button btnConfirmPayment;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new Label();
            this.lblDebt = new Label();
            this.cmbDebts = new ComboBox();
            this.lblPaymentAmount = new Label();
            this.txtPaymentAmount = new TextBox();
            this.lblPaymentDate = new Label();
            this.dtpPaymentDate = new DateTimePicker();
            this.lblAfterPayment = new Label();
            this.btnConfirmPayment = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            this.lblTitle.Text = "Make Payment";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.Bounds = new Rectangle(20, 18, 360, 32);

            this.lblDebt.Text = "Debt";
            this.lblDebt.ForeColor = Color.LightGray;
            this.lblDebt.Font = new Font("Segoe UI", 9F);
            this.lblDebt.Bounds = new Rectangle(20, 60, 360, 18);

            this.cmbDebts.BackColor = Color.FromArgb(55, 55, 75);
            this.cmbDebts.ForeColor = Color.White;
            this.cmbDebts.Font = new Font("Segoe UI", 10F);
            this.cmbDebts.Bounds = new Rectangle(20, 80, 360, 28);
            this.cmbDebts.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDebts.Name = "cmbDebts";
            this.cmbDebts.SelectedIndexChanged += new EventHandler(this.cmbDebts_SelectedIndexChanged);

            this.lblPaymentAmount.Text = "Payment Amount (৳)";
            this.lblPaymentAmount.ForeColor = Color.LightGray;
            this.lblPaymentAmount.Font = new Font("Segoe UI", 9F);
            this.lblPaymentAmount.Bounds = new Rectangle(20, 122, 360, 18);

            this.txtPaymentAmount.BackColor = Color.FromArgb(55, 55, 75);
            this.txtPaymentAmount.ForeColor = Color.White;
            this.txtPaymentAmount.Font = new Font("Segoe UI", 10F);
            this.txtPaymentAmount.Bounds = new Rectangle(20, 142, 360, 28);
            this.txtPaymentAmount.BorderStyle = BorderStyle.FixedSingle;
            this.txtPaymentAmount.Name = "txtPaymentAmount";
            this.txtPaymentAmount.TextChanged += new EventHandler(this.txtPaymentAmount_TextChanged);

            this.lblPaymentDate.Text = "Payment Date";
            this.lblPaymentDate.ForeColor = Color.LightGray;
            this.lblPaymentDate.Font = new Font("Segoe UI", 9F);
            this.lblPaymentDate.Bounds = new Rectangle(20, 184, 360, 18);

            this.dtpPaymentDate.Bounds = new Rectangle(20, 204, 360, 28);
            this.dtpPaymentDate.Format = DateTimePickerFormat.Short;
            this.dtpPaymentDate.Font = new Font("Segoe UI", 10F);
            this.dtpPaymentDate.Value = DateTime.Today;
            this.dtpPaymentDate.Name = "dtpPaymentDate";

            this.lblAfterPayment.Text = "After payment: Outstanding = ৳ 0.00";
            this.lblAfterPayment.ForeColor = Color.LightGray;
            this.lblAfterPayment.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblAfterPayment.Bounds = new Rectangle(20, 245, 360, 24);

            this.btnConfirmPayment.Text = "Confirm Payment";
            this.btnConfirmPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnConfirmPayment.ForeColor = Color.White;
            this.btnConfirmPayment.BackColor = Color.FromArgb(80, 120, 220);
            this.btnConfirmPayment.FlatStyle = FlatStyle.Flat;
            this.btnConfirmPayment.FlatAppearance.BorderSize = 0;
            this.btnConfirmPayment.Bounds = new Rectangle(20, 284, 170, 38);
            this.btnConfirmPayment.Cursor = Cursors.Hand;
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Click += new EventHandler(this.btnConfirmPayment_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.LightGray;
            this.btnCancel.BackColor = Color.FromArgb(70, 70, 90);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Bounds = new Rectangle(210, 284, 170, 38);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            this.ClientSize = new Size(400, 344);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Make Payment";
            this.Name = "DebtPaymentForm";
            this.BackColor = Color.FromArgb(25, 25, 40);
            this.Font = new Font("Segoe UI", 9F);

            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDebt,
                this.cmbDebts,
                this.lblPaymentAmount,
                this.txtPaymentAmount,
                this.lblPaymentDate,
                this.dtpPaymentDate,
                this.lblAfterPayment,
                this.btnConfirmPayment,
                this.btnCancel
            });

            this.ResumeLayout(false);
        }
    }
}
