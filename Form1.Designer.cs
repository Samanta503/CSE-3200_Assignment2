using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabMain;
        private TabPage tabFinance;
        private TabPage tabDebt;

        private Panel pnlSummary;
        private Label lblIncomeTitle;
        private Label lblIncomeValue;
        private Label lblExpenseTitle;
        private Label lblExpenseValue;
        private Label lblBalanceTitle;
        private Label lblBalanceValue;

        private Panel pnlEntry;
        private Label lblAmount;
        private TextBox txtAmount;
        private Label lblCategory;
        private ComboBox cboCategory;
        private GroupBox grpType;
        private RadioButton rdoIncome;
        private RadioButton rdoExpense;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnAdd;

        private DataGridView dgvTransactions;
        private Button btnDelete;

        private Panel pnlDebtEntry;
        private Label lblDebtName;
        private TextBox txtDebtName;
        private Label lblDebtAmount;
        private TextBox txtDebtAmount;
        private Label lblInterestRate;
        private TextBox txtInterestRate;
        private Label lblDebtDueDate;
        private DateTimePicker dtpDebtDueDate;
        private Label lblDebtType;
        private ComboBox cmbDebtType;
        private Button btnAddDebt;

        private DataGridView dgvDebts;
        private Button btnMakePayment;
        private Button btnDeleteDebt;

        private Panel pnlDebtSummary;
        private Label lblTotalDebtTitle;
        private Label lblTotalDebtValue;
        private Label lblTotalPaidTitle;
        private Label lblTotalPaidValue;
        private Label lblOutstandingTitle;
        private Label lblOutstandingValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.tabMain = new TabControl();
            this.tabFinance = new TabPage();
            this.tabDebt = new TabPage();

            this.pnlSummary = new Panel();
            this.lblIncomeTitle = new Label();
            this.lblIncomeValue = new Label();
            this.lblExpenseTitle = new Label();
            this.lblExpenseValue = new Label();
            this.lblBalanceTitle = new Label();
            this.lblBalanceValue = new Label();

            this.pnlEntry = new Panel();
            this.lblAmount = new Label();
            this.txtAmount = new TextBox();
            this.lblCategory = new Label();
            this.cboCategory = new ComboBox();
            this.grpType = new GroupBox();
            this.rdoIncome = new RadioButton();
            this.rdoExpense = new RadioButton();
            this.lblDate = new Label();
            this.dtpDate = new DateTimePicker();
            this.lblNotes = new Label();
            this.txtNotes = new TextBox();
            this.btnAdd = new Button();

            this.dgvTransactions = new DataGridView();
            this.btnDelete = new Button();

            this.pnlDebtEntry = new Panel();
            this.lblDebtName = new Label();
            this.txtDebtName = new TextBox();
            this.lblDebtAmount = new Label();
            this.txtDebtAmount = new TextBox();
            this.lblInterestRate = new Label();
            this.txtInterestRate = new TextBox();
            this.lblDebtDueDate = new Label();
            this.dtpDebtDueDate = new DateTimePicker();
            this.lblDebtType = new Label();
            this.cmbDebtType = new ComboBox();
            this.btnAddDebt = new Button();

            this.dgvDebts = new DataGridView();
            this.btnMakePayment = new Button();
            this.btnDeleteDebt = new Button();

            this.pnlDebtSummary = new Panel();
            this.lblTotalDebtTitle = new Label();
            this.lblTotalDebtValue = new Label();
            this.lblTotalPaidTitle = new Label();
            this.lblTotalPaidValue = new Label();
            this.lblOutstandingTitle = new Label();
            this.lblOutstandingValue = new Label();

            this.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabFinance.SuspendLayout();
            this.tabDebt.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            this.grpType.SuspendLayout();
            this.pnlDebtEntry.SuspendLayout();
            this.pnlDebtSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).BeginInit();

            this.tabMain.Dock = DockStyle.Fill;
            this.tabMain.Name = "tabMain";
            this.tabMain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.tabMain.TabPages.Add(this.tabFinance);
            this.tabMain.TabPages.Add(this.tabDebt);

            this.tabFinance.Text = "  Finance  ";
            this.tabFinance.Name = "tabFinance";
            this.tabFinance.BackColor = Color.FromArgb(25, 25, 40);
            this.tabFinance.UseVisualStyleBackColor = false;

            this.tabDebt.Text = "  Debt Tracker  ";
            this.tabDebt.Name = "tabDebt";
            this.tabDebt.BackColor = Color.FromArgb(25, 25, 40);
            this.tabDebt.UseVisualStyleBackColor = false;

            // Finance summary panel
            this.pnlSummary.BackColor = Color.FromArgb(30, 30, 45);
            this.pnlSummary.Bounds = new Rectangle(0, 0, 900, 90);
            this.pnlSummary.Name = "pnlSummary";

            this.lblIncomeTitle.Text = "TOTAL INCOME";
            this.lblIncomeTitle.ForeColor = Color.LightGray;
            this.lblIncomeTitle.Font = new Font("Segoe UI", 9F);
            this.lblIncomeTitle.Bounds = new Rectangle(40, 12, 200, 20);

            this.lblIncomeValue.Text = "৳ 0.00";
            this.lblIncomeValue.ForeColor = Color.LimeGreen;
            this.lblIncomeValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblIncomeValue.Bounds = new Rectangle(40, 32, 220, 45);

            this.lblExpenseTitle.Text = "TOTAL EXPENSES";
            this.lblExpenseTitle.ForeColor = Color.LightGray;
            this.lblExpenseTitle.Font = new Font("Segoe UI", 9F);
            this.lblExpenseTitle.Bounds = new Rectangle(320, 12, 200, 20);

            this.lblExpenseValue.Text = "৳ 0.00";
            this.lblExpenseValue.ForeColor = Color.OrangeRed;
            this.lblExpenseValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblExpenseValue.Bounds = new Rectangle(320, 32, 220, 45);

            this.lblBalanceTitle.Text = "NET BALANCE";
            this.lblBalanceTitle.ForeColor = Color.LightGray;
            this.lblBalanceTitle.Font = new Font("Segoe UI", 9F);
            this.lblBalanceTitle.Bounds = new Rectangle(620, 12, 200, 20);

            this.lblBalanceValue.Text = "৳ 0.00";
            this.lblBalanceValue.ForeColor = Color.LightGray;
            this.lblBalanceValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblBalanceValue.Bounds = new Rectangle(620, 32, 250, 45);

            this.pnlSummary.Controls.AddRange(new Control[]
            {
                this.lblIncomeTitle, this.lblIncomeValue,
                this.lblExpenseTitle, this.lblExpenseValue,
                this.lblBalanceTitle, this.lblBalanceValue
            });

            // Finance input panel
            this.pnlEntry.BackColor = Color.FromArgb(40, 40, 58);
            this.pnlEntry.Bounds = new Rectangle(0, 90, 280, 510);
            this.pnlEntry.Name = "pnlEntry";

            this.lblAmount.Text = "Amount (৳)";
            this.lblAmount.ForeColor = Color.LightGray;
            this.lblAmount.Font = new Font("Segoe UI", 9F);
            this.lblAmount.Bounds = new Rectangle(15, 18, 240, 18);

            this.txtAmount.BackColor = Color.FromArgb(55, 55, 75);
            this.txtAmount.ForeColor = Color.White;
            this.txtAmount.Font = new Font("Segoe UI", 10F);
            this.txtAmount.Bounds = new Rectangle(15, 38, 248, 28);
            this.txtAmount.BorderStyle = BorderStyle.FixedSingle;

            this.lblCategory.Text = "Category";
            this.lblCategory.ForeColor = Color.LightGray;
            this.lblCategory.Font = new Font("Segoe UI", 9F);
            this.lblCategory.Bounds = new Rectangle(15, 80, 240, 18);

            this.cboCategory.BackColor = Color.FromArgb(55, 55, 75);
            this.cboCategory.ForeColor = Color.White;
            this.cboCategory.Font = new Font("Segoe UI", 10F);
            this.cboCategory.Bounds = new Rectangle(15, 100, 248, 28);
            this.cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboCategory.Items.AddRange(new object[] { "Salary", "Freelance", "Food", "Transport", "Utilities", "Other" });

            this.grpType.Text = "Transaction Type";
            this.grpType.ForeColor = Color.LightGray;
            this.grpType.Font = new Font("Segoe UI", 9F);
            this.grpType.Bounds = new Rectangle(15, 142, 248, 65);
            this.grpType.BackColor = Color.FromArgb(40, 40, 58);

            this.rdoIncome.Text = "Income";
            this.rdoIncome.ForeColor = Color.LimeGreen;
            this.rdoIncome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.rdoIncome.Bounds = new Rectangle(12, 24, 90, 24);

            this.rdoExpense.Text = "Expense";
            this.rdoExpense.ForeColor = Color.OrangeRed;
            this.rdoExpense.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.rdoExpense.Bounds = new Rectangle(130, 24, 100, 24);

            this.grpType.Controls.Add(this.rdoIncome);
            this.grpType.Controls.Add(this.rdoExpense);

            this.lblDate.Text = "Date";
            this.lblDate.ForeColor = Color.LightGray;
            this.lblDate.Font = new Font("Segoe UI", 9F);
            this.lblDate.Bounds = new Rectangle(15, 222, 240, 18);

            this.dtpDate.Bounds = new Rectangle(15, 242, 248, 28);
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Font = new Font("Segoe UI", 10F);

            this.lblNotes.Text = "Notes (optional)";
            this.lblNotes.ForeColor = Color.LightGray;
            this.lblNotes.Font = new Font("Segoe UI", 9F);
            this.lblNotes.Bounds = new Rectangle(15, 285, 240, 18);

            this.txtNotes.BackColor = Color.FromArgb(55, 55, 75);
            this.txtNotes.ForeColor = Color.White;
            this.txtNotes.Font = new Font("Segoe UI", 10F);
            this.txtNotes.Bounds = new Rectangle(15, 305, 248, 60);
            this.txtNotes.Multiline = true;
            this.txtNotes.BorderStyle = BorderStyle.FixedSingle;

            this.btnAdd.Text = "+ Add Transaction";
            this.btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAdd.ForeColor = Color.White;
            this.btnAdd.BackColor = Color.FromArgb(80, 120, 220);
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Bounds = new Rectangle(15, 385, 248, 42);
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);

            this.pnlEntry.Controls.AddRange(new Control[]
            {
                this.lblAmount, this.txtAmount,
                this.lblCategory, this.cboCategory,
                this.grpType,
                this.lblDate, this.dtpDate,
                this.lblNotes, this.txtNotes,
                this.btnAdd
            });

            // Finance DataGridView
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Bounds = new Rectangle(290, 90, 610, 460);
            this.dgvTransactions.BackgroundColor = Color.FromArgb(25, 25, 40);
            this.dgvTransactions.GridColor = Color.FromArgb(60, 60, 80);
            this.dgvTransactions.BorderStyle = BorderStyle.None;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransactions.AutoGenerateColumns = false;
            this.dgvTransactions.Font = new Font("Segoe UI", 9.5F);
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 70);
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.dgvTransactions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvTransactions.ColumnHeadersHeight = 36;
            this.dgvTransactions.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 52);
            this.dgvTransactions.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            this.dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 120, 220);
            this.dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvTransactions.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            this.dgvTransactions.RowTemplate.Height = 30;
            this.dgvTransactions.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(42, 42, 62);

            var colDate = new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date", DataPropertyName = "Date" };
            var colType = new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Type", DataPropertyName = "Type" };
            var colCategory = new DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "Category", DataPropertyName = "Category" };
            var colAmount = new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = "Amount", DataPropertyName = "AmountText" };
            var colNotes = new DataGridViewTextBoxColumn { Name = "colNotes", HeaderText = "Notes", DataPropertyName = "Notes" };
            colDate.DefaultCellStyle.Format = "dd/MM/yyyy";
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colDate.FillWeight = 80F;
            colType.FillWeight = 70F;
            colCategory.FillWeight = 90F;
            colAmount.FillWeight = 80F;
            colNotes.FillWeight = 180F;
            this.dgvTransactions.Columns.AddRange(new DataGridViewColumn[] { colDate, colType, colCategory, colAmount, colNotes });

            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.BackColor = Color.FromArgb(180, 60, 60);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Bounds = new Rectangle(290, 558, 610, 36);
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.tabFinance.Controls.AddRange(new Control[] { this.pnlSummary, this.pnlEntry, this.dgvTransactions, this.btnDelete });

            // Debt input panel
            this.pnlDebtEntry.BackColor = Color.FromArgb(40, 40, 58);
            this.pnlDebtEntry.Bounds = new Rectangle(0, 0, 280, 510);
            this.pnlDebtEntry.Name = "pnlDebtEntry";

            this.lblDebtName.Text = "Creditor / Debtor Name";
            this.lblDebtName.ForeColor = Color.LightGray;
            this.lblDebtName.Font = new Font("Segoe UI", 9F);
            this.lblDebtName.Bounds = new Rectangle(15, 18, 240, 18);

            this.txtDebtName.BackColor = Color.FromArgb(55, 55, 75);
            this.txtDebtName.ForeColor = Color.White;
            this.txtDebtName.Font = new Font("Segoe UI", 10F);
            this.txtDebtName.Bounds = new Rectangle(15, 38, 248, 28);
            this.txtDebtName.BorderStyle = BorderStyle.FixedSingle;

            this.lblDebtAmount.Text = "Total Debt Amount (৳)";
            this.lblDebtAmount.ForeColor = Color.LightGray;
            this.lblDebtAmount.Font = new Font("Segoe UI", 9F);
            this.lblDebtAmount.Bounds = new Rectangle(15, 80, 240, 18);

            this.txtDebtAmount.BackColor = Color.FromArgb(55, 55, 75);
            this.txtDebtAmount.ForeColor = Color.White;
            this.txtDebtAmount.Font = new Font("Segoe UI", 10F);
            this.txtDebtAmount.Bounds = new Rectangle(15, 100, 248, 28);
            this.txtDebtAmount.BorderStyle = BorderStyle.FixedSingle;

            this.lblInterestRate.Text = "Interest Rate (%)";
            this.lblInterestRate.ForeColor = Color.LightGray;
            this.lblInterestRate.Font = new Font("Segoe UI", 9F);
            this.lblInterestRate.Bounds = new Rectangle(15, 142, 240, 18);

            this.txtInterestRate.BackColor = Color.FromArgb(55, 55, 75);
            this.txtInterestRate.ForeColor = Color.White;
            this.txtInterestRate.Font = new Font("Segoe UI", 10F);
            this.txtInterestRate.Bounds = new Rectangle(15, 162, 248, 28);
            this.txtInterestRate.BorderStyle = BorderStyle.FixedSingle;

            this.lblDebtDueDate.Text = "Due Date";
            this.lblDebtDueDate.ForeColor = Color.LightGray;
            this.lblDebtDueDate.Font = new Font("Segoe UI", 9F);
            this.lblDebtDueDate.Bounds = new Rectangle(15, 204, 240, 18);

            this.dtpDebtDueDate.Bounds = new Rectangle(15, 224, 248, 28);
            this.dtpDebtDueDate.Format = DateTimePickerFormat.Short;
            this.dtpDebtDueDate.Font = new Font("Segoe UI", 10F);

            this.lblDebtType.Text = "Debt Type";
            this.lblDebtType.ForeColor = Color.LightGray;
            this.lblDebtType.Font = new Font("Segoe UI", 9F);
            this.lblDebtType.Bounds = new Rectangle(15, 266, 240, 18);

            this.cmbDebtType.BackColor = Color.FromArgb(55, 55, 75);
            this.cmbDebtType.ForeColor = Color.White;
            this.cmbDebtType.Font = new Font("Segoe UI", 10F);
            this.cmbDebtType.Bounds = new Rectangle(15, 286, 248, 28);
            this.cmbDebtType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDebtType.Items.AddRange(new object[] { "I Owe", "Owed to Me" });

            this.btnAddDebt.Text = "+ Add Debt";
            this.btnAddDebt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddDebt.ForeColor = Color.White;
            this.btnAddDebt.BackColor = Color.FromArgb(80, 120, 220);
            this.btnAddDebt.FlatStyle = FlatStyle.Flat;
            this.btnAddDebt.FlatAppearance.BorderSize = 0;
            this.btnAddDebt.Bounds = new Rectangle(15, 340, 248, 42);
            this.btnAddDebt.Cursor = Cursors.Hand;
            this.btnAddDebt.Click += new EventHandler(this.btnAddDebt_Click);

            this.pnlDebtEntry.Controls.AddRange(new Control[]
            {
                this.lblDebtName, this.txtDebtName,
                this.lblDebtAmount, this.txtDebtAmount,
                this.lblInterestRate, this.txtInterestRate,
                this.lblDebtDueDate, this.dtpDebtDueDate,
                this.lblDebtType, this.cmbDebtType,
                this.btnAddDebt
            });

            // Debt DataGridView
            this.dgvDebts.Name = "dgvDebts";
            this.dgvDebts.Bounds = new Rectangle(290, 0, 610, 460);
            this.dgvDebts.BackgroundColor = Color.FromArgb(25, 25, 40);
            this.dgvDebts.GridColor = Color.FromArgb(60, 60, 80);
            this.dgvDebts.BorderStyle = BorderStyle.None;
            this.dgvDebts.RowHeadersVisible = false;
            this.dgvDebts.AllowUserToAddRows = false;
            this.dgvDebts.AllowUserToDeleteRows = false;
            this.dgvDebts.ReadOnly = true;
            this.dgvDebts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDebts.MultiSelect = false;
            this.dgvDebts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDebts.AutoGenerateColumns = false;
            this.dgvDebts.Font = new Font("Segoe UI", 9.5F);
            this.dgvDebts.EnableHeadersVisualStyles = false;
            this.dgvDebts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 70);
            this.dgvDebts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvDebts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.dgvDebts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvDebts.ColumnHeadersHeight = 36;
            this.dgvDebts.DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 52);
            this.dgvDebts.DefaultCellStyle.ForeColor = Color.WhiteSmoke;
            this.dgvDebts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 120, 220);
            this.dgvDebts.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvDebts.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            this.dgvDebts.RowTemplate.Height = 30;
            this.dgvDebts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(42, 42, 62);

            var colDebtId = new DataGridViewTextBoxColumn { Name = "colDebtId", HeaderText = "Id", DataPropertyName = "Id", Visible = false };
            var colDebtName = new DataGridViewTextBoxColumn { Name = "colDebtName", HeaderText = "Name", DataPropertyName = "Name" };
            var colDebtType = new DataGridViewTextBoxColumn { Name = "colDebtType", HeaderText = "Type", DataPropertyName = "Type" };
            var colOriginalAmount = new DataGridViewTextBoxColumn { Name = "colOriginalAmount", HeaderText = "Original Amount", DataPropertyName = "OriginalAmountText" };
            var colAmountPaid = new DataGridViewTextBoxColumn { Name = "colAmountPaid", HeaderText = "Amount Paid", DataPropertyName = "AmountPaidText" };
            var colOutstanding = new DataGridViewTextBoxColumn { Name = "colOutstanding", HeaderText = "Outstanding", DataPropertyName = "OutstandingText" };
            var colDueDate = new DataGridViewTextBoxColumn { Name = "colDueDate", HeaderText = "Due Date", DataPropertyName = "DueDateText" };
            var colDebtStatus = new DataGridViewTextBoxColumn { Name = "colDebtStatus", HeaderText = "Status", DataPropertyName = "Status" };
            colDebtName.FillWeight = 110F;
            colDebtType.FillWeight = 85F;
            colOriginalAmount.FillWeight = 95F;
            colAmountPaid.FillWeight = 90F;
            colOutstanding.FillWeight = 95F;
            colDueDate.FillWeight = 80F;
            colDebtStatus.FillWeight = 75F;
            colOriginalAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmountPaid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colOutstanding.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvDebts.Columns.AddRange(new DataGridViewColumn[]
            {
                colDebtId, colDebtName, colDebtType, colOriginalAmount, colAmountPaid, colOutstanding, colDueDate, colDebtStatus
            });

            this.btnMakePayment.Text = "Make Payment";
            this.btnMakePayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnMakePayment.ForeColor = Color.White;
            this.btnMakePayment.BackColor = Color.FromArgb(80, 120, 220);
            this.btnMakePayment.FlatStyle = FlatStyle.Flat;
            this.btnMakePayment.FlatAppearance.BorderSize = 0;
            this.btnMakePayment.Bounds = new Rectangle(290, 468, 296, 36);
            this.btnMakePayment.Cursor = Cursors.Hand;
            this.btnMakePayment.Click += new EventHandler(this.btnMakePayment_Click);

            this.btnDeleteDebt.Text = "Delete Debt";
            this.btnDeleteDebt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDeleteDebt.ForeColor = Color.White;
            this.btnDeleteDebt.BackColor = Color.FromArgb(180, 60, 60);
            this.btnDeleteDebt.FlatStyle = FlatStyle.Flat;
            this.btnDeleteDebt.FlatAppearance.BorderSize = 0;
            this.btnDeleteDebt.Bounds = new Rectangle(604, 468, 296, 36);
            this.btnDeleteDebt.Cursor = Cursors.Hand;
            this.btnDeleteDebt.Click += new EventHandler(this.btnDeleteDebt_Click);

            // Debt summary panel
            this.pnlDebtSummary.BackColor = Color.FromArgb(30, 30, 45);
            this.pnlDebtSummary.Bounds = new Rectangle(0, 510, 900, 90);
            this.pnlDebtSummary.Name = "pnlDebtSummary";

            this.lblTotalDebtTitle.Text = "TOTAL DEBT OUTSTANDING";
            this.lblTotalDebtTitle.ForeColor = Color.LightGray;
            this.lblTotalDebtTitle.Font = new Font("Segoe UI", 9F);
            this.lblTotalDebtTitle.Bounds = new Rectangle(40, 12, 240, 20);

            this.lblTotalDebtValue.Text = "৳ 0.00";
            this.lblTotalDebtValue.ForeColor = Color.OrangeRed;
            this.lblTotalDebtValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTotalDebtValue.Bounds = new Rectangle(40, 32, 240, 45);

            this.lblTotalPaidTitle.Text = "TOTAL OWED TO ME";
            this.lblTotalPaidTitle.ForeColor = Color.LightGray;
            this.lblTotalPaidTitle.Font = new Font("Segoe UI", 9F);
            this.lblTotalPaidTitle.Bounds = new Rectangle(320, 12, 220, 20);

            this.lblTotalPaidValue.Text = "৳ 0.00";
            this.lblTotalPaidValue.ForeColor = Color.LimeGreen;
            this.lblTotalPaidValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTotalPaidValue.Bounds = new Rectangle(320, 32, 220, 45);

            this.lblOutstandingTitle.Text = "NET DEBT POSITION";
            this.lblOutstandingTitle.ForeColor = Color.LightGray;
            this.lblOutstandingTitle.Font = new Font("Segoe UI", 9F);
            this.lblOutstandingTitle.Bounds = new Rectangle(620, 12, 220, 20);

            this.lblOutstandingValue.Text = "৳ 0.00";
            this.lblOutstandingValue.ForeColor = Color.LightGray;
            this.lblOutstandingValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblOutstandingValue.Bounds = new Rectangle(620, 32, 250, 45);

            this.pnlDebtSummary.Controls.AddRange(new Control[]
            {
                this.lblTotalDebtTitle, this.lblTotalDebtValue,
                this.lblTotalPaidTitle, this.lblTotalPaidValue,
                this.lblOutstandingTitle, this.lblOutstandingValue
            });

            this.tabDebt.Controls.AddRange(new Control[]
            {
                this.pnlDebtEntry,
                this.dgvDebts,
                this.btnMakePayment,
                this.btnDeleteDebt,
                this.pnlDebtSummary
            });

            this.ClientSize = new Size(900, 630);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Personal Finance Tracker";
            this.Name = "Form1";
            this.BackColor = Color.FromArgb(25, 25, 40);
            this.Font = new Font("Segoe UI", 9F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.Add(this.tabMain);

            this.grpType.ResumeLayout(false);
            this.pnlEntry.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlDebtEntry.ResumeLayout(false);
            this.pnlDebtSummary.ResumeLayout(false);
            this.tabFinance.ResumeLayout(false);
            this.tabDebt.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebts)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
