using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{
    public partial class Form1 : Form
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();
        private readonly DebtRepository _debtRepository;

        public Form1()
        {
            InitializeComponent();

            _debtRepository = new DebtRepository();
            _debtRepository.InitializeDatabase();

            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
            dgvDebts.CellFormatting += DgvDebts_CellFormatting;

            dtpDate.Value = DateTime.Today;
            dtpDebtDueDate.Value = DateTime.Today;
            cmbDebtType.SelectedIndex = 0;
            txtInterestRate.Text = "0";

            RefreshGrid();
            RefreshSummary();
            LoadDebts();
            UpdateDebtSummary();
        }

        // =====================================================================
        // Assignment 1: Finance tab
        // =====================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text.Trim(), out amount))
            {
                MessageBox.Show("Please enter a valid numeric amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            if (amount <= 0)
            {
                MessageBox.Show("Amount must be greater than zero.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            if (cboCategory.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a category.", "Category Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            if (!rdoIncome.Checked && !rdoExpense.Checked)
            {
                MessageBox.Show("Please select a transaction type: Income or Expense.", "Type Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string type = rdoIncome.Checked ? "Income" : "Expense";
            string category = cboCategory.SelectedItem.ToString();
            DateTime date = dtpDate.Value.Date;
            string notes = txtNotes.Text.Trim();

            _transactions.Add(new Transaction(date, type, category, amount, notes));

            RefreshGrid();
            RefreshSummary();
            ClearInputFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int selectedIndex = dgvTransactions.SelectedRows[0].Index;
            if (selectedIndex < 0 || selectedIndex >= _transactions.Count)
                return;

            _transactions.RemoveAt(selectedIndex);
            RefreshGrid();
            RefreshSummary();
        }

        private void RefreshGrid()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.DataSource = null;
            dgvTransactions.DataSource = _transactions.Select(t => new
            {
                Date = t.Date,
                Type = t.Type,
                Category = t.Category,
                AmountText = FormatCurrency(t.Amount),
                Notes = t.Notes
            }).ToList();
        }

        private void RefreshSummary()
        {
            decimal totalIncome = _transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            decimal totalExpense = _transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            decimal netBalance = totalIncome - totalExpense;

            lblIncomeValue.Text = FormatCurrency(totalIncome);
            lblExpenseValue.Text = FormatCurrency(totalExpense);
            lblBalanceValue.Text = FormatCurrency(netBalance);

            if (netBalance < 0)
                lblBalanceValue.ForeColor = Color.OrangeRed;
            else if (netBalance > 0)
                lblBalanceValue.ForeColor = Color.LimeGreen;
            else
                lblBalanceValue.ForeColor = Color.LightGray;
        }

        private void ClearInputFields()
        {
            txtAmount.Clear();
            cboCategory.SelectedIndex = -1;
            rdoIncome.Checked = false;
            rdoExpense.Checked = false;
            dtpDate.Value = DateTime.Today;
            txtNotes.Clear();
            txtAmount.Focus();
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvTransactions.Columns[e.ColumnIndex].Name == "colType" && e.Value != null)
            {
                e.CellStyle.ForeColor = e.Value.ToString() == "Income" ? Color.LimeGreen : Color.OrangeRed;
                e.CellStyle.Font = new Font(dgvTransactions.Font, FontStyle.Bold);
            }
        }

        // =====================================================================
        // Assignment 2: Debt Tracker tab
        // =====================================================================
        private void btnAddDebt_Click(object sender, EventArgs e)
        {
            string name = txtDebtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter creditor/debtor name.", "Name Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDebtName.Focus();
                return;
            }

            decimal originalAmount;
            if (!decimal.TryParse(txtDebtAmount.Text.Trim(), out originalAmount))
            {
                MessageBox.Show("Please enter a valid debt amount.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDebtAmount.Focus();
                return;
            }

            if (originalAmount <= 0)
            {
                MessageBox.Show("Debt amount must be greater than zero.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDebtAmount.Focus();
                return;
            }

            decimal interestRate;
            if (!decimal.TryParse(txtInterestRate.Text.Trim(), out interestRate))
            {
                MessageBox.Show("Please enter a valid interest rate.", "Invalid Interest Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInterestRate.Focus();
                return;
            }

            if (interestRate < 0 || interestRate > 100)
            {
                MessageBox.Show("Interest rate must be between 0 and 100.", "Invalid Interest Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInterestRate.Focus();
                return;
            }

            if (cmbDebtType.SelectedIndex < 0)
            {
                MessageBox.Show("Please select debt type.", "Debt Type Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDebtType.Focus();
                return;
            }

            var debt = new Debt
            {
                Name = name,
                Type = cmbDebtType.SelectedItem.ToString(),
                OriginalAmount = originalAmount,
                InterestRate = interestRate,
                AmountPaid = 0m,
                DueDate = dtpDebtDueDate.Value.Date
            };

            try
            {
                _debtRepository.AddDebt(debt);
                LoadDebts();
                UpdateDebtSummary();
                ClearDebtFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            int debtId = GetSelectedDebtId();
            if (debtId <= 0)
            {
                MessageBox.Show("Please select a debt record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Debt selectedDebt = _debtRepository.GetDebtById(debtId);
            if (selectedDebt == null)
            {
                MessageBox.Show("Selected debt record was not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedDebt.Outstanding <= 0)
            {
                MessageBox.Show("This debt is already fully paid.", "Already Paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var paymentForm = new DebtPaymentForm(_debtRepository, debtId))
            {
                if (paymentForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadDebts();
                    UpdateDebtSummary();
                }
            }
        }

        private void btnDeleteDebt_Click(object sender, EventArgs e)
        {
            int debtId = GetSelectedDebtId();
            if (debtId <= 0)
            {
                MessageBox.Show("Please select a debt record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this debt record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                _debtRepository.DeleteDebt(debtId);
                LoadDebts();
                UpdateDebtSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDebts()
        {
            List<Debt> debts = _debtRepository.GetAllDebts();

            dgvDebts.AutoGenerateColumns = false;
            dgvDebts.DataSource = null;
            dgvDebts.DataSource = debts.Select(d => new
            {
                Id = d.Id,
                Name = d.Name,
                Type = d.Type,
                OriginalAmountText = FormatCurrency(d.OriginalAmount),
                AmountPaidText = FormatCurrency(d.AmountPaid),
                OutstandingText = FormatCurrency(d.Outstanding),
                DueDateText = d.DueDate.ToString("dd/MM/yyyy"),
                Status = d.Status
            }).ToList();

            foreach (DataGridViewRow row in dgvDebts.Rows)
            {
                if (row.Cells["colDebtStatus"].Value == null) continue;

                string status = row.Cells["colDebtStatus"].Value.ToString();
                if (status == "Overdue")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(90, 45, 50);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                else if (status == "Paid")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(38, 75, 52);
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void UpdateDebtSummary()
        {
            decimal totalDebtOutstanding = _debtRepository.GetTotalDebtOutstanding();
            decimal totalOwedToMe = _debtRepository.GetTotalOwedToMe();
            decimal netDebtPosition = _debtRepository.GetNetDebtPosition();

            lblTotalDebtValue.Text = FormatCurrency(totalDebtOutstanding);
            lblTotalPaidValue.Text = FormatCurrency(totalOwedToMe);
            lblOutstandingValue.Text = FormatCurrency(netDebtPosition);

            lblTotalDebtValue.ForeColor = Color.OrangeRed;
            lblTotalPaidValue.ForeColor = Color.LimeGreen;

            if (netDebtPosition < 0)
                lblOutstandingValue.ForeColor = Color.OrangeRed;
            else if (netDebtPosition > 0)
                lblOutstandingValue.ForeColor = Color.LimeGreen;
            else
                lblOutstandingValue.ForeColor = Color.LightGray;
        }

        private void ClearDebtFields()
        {
            txtDebtName.Clear();
            txtDebtAmount.Clear();
            txtInterestRate.Text = "0";
            dtpDebtDueDate.Value = DateTime.Today;
            cmbDebtType.SelectedIndex = 0;
            txtDebtName.Focus();
        }

        private int GetSelectedDebtId()
        {
            if (dgvDebts.SelectedRows.Count == 0)
                return -1;

            object value = dgvDebts.SelectedRows[0].Cells["colDebtId"].Value;
            if (value == null)
                return -1;

            int id;
            return int.TryParse(value.ToString(), out id) ? id : -1;
        }

        private void DgvDebts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string columnName = dgvDebts.Columns[e.ColumnIndex].Name;
            if (columnName == "colDebtType" && e.Value != null)
            {
                e.CellStyle.ForeColor = e.Value.ToString() == "Owed to Me" ? Color.LimeGreen : Color.OrangeRed;
                e.CellStyle.Font = new Font(dgvDebts.Font, FontStyle.Bold);
            }

            if (columnName == "colDebtStatus" && e.Value != null)
            {
                string status = e.Value.ToString();
                if (status == "Paid") e.CellStyle.ForeColor = Color.LimeGreen;
                else if (status == "Overdue") e.CellStyle.ForeColor = Color.OrangeRed;
                else e.CellStyle.ForeColor = Color.Gold;

                e.CellStyle.Font = new Font(dgvDebts.Font, FontStyle.Bold);
            }
        }

        private string FormatCurrency(decimal amount)
        {
            if (amount < 0)
                return "-৳ " + Math.Abs(amount).ToString("N2");

            return "৳ " + amount.ToString("N2");
        }
    }
}
