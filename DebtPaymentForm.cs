using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PersonalFinanceTracker
{
    public partial class DebtPaymentForm : Form
    {
        private readonly DebtRepository _repository;
        private Debt _selectedDebt;

        public DebtPaymentForm(DebtRepository repository, int selectedDebtId)
        {
            _repository = repository;
            InitializeComponent();
            LoadDebtCombo(selectedDebtId);
            UpdateOutstandingPreview();
        }

        private void LoadDebtCombo(int selectedDebtId)
        {
            List<Debt> debts = _repository.GetAllDebts().FindAll(d => d.Outstanding > 0);
            cmbDebts.Items.Clear();

            foreach (Debt debt in debts)
            {
                cmbDebts.Items.Add(new DebtComboItem(debt));
            }

            for (int i = 0; i < cmbDebts.Items.Count; i++)
            {
                var item = (DebtComboItem)cmbDebts.Items[i];
                if (item.Debt.Id == selectedDebtId)
                {
                    cmbDebts.SelectedIndex = i;
                    return;
                }
            }

            if (cmbDebts.Items.Count > 0)
                cmbDebts.SelectedIndex = 0;
        }

        private void cmbDebts_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cmbDebts.SelectedItem as DebtComboItem;
            _selectedDebt = item != null ? item.Debt : null;
            UpdateOutstandingPreview();
        }

        private void txtPaymentAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateOutstandingPreview();
        }

        private void UpdateOutstandingPreview()
        {
            if (_selectedDebt == null)
            {
                lblAfterPayment.Text = "After payment: Outstanding = ৳ 0.00";
                return;
            }

            decimal paymentAmount;
            if (!decimal.TryParse(txtPaymentAmount.Text.Trim(), out paymentAmount))
                paymentAmount = 0m;

            decimal afterPayment = _selectedDebt.Outstanding - paymentAmount;
            if (afterPayment < 0) afterPayment = 0m;

            lblAfterPayment.Text = "After payment: Outstanding = " + FormatCurrency(afterPayment);
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (_selectedDebt == null)
            {
                MessageBox.Show("Please select a debt record.", "Debt Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal paymentAmount;
            if (!decimal.TryParse(txtPaymentAmount.Text.Trim(), out paymentAmount))
            {
                MessageBox.Show("Please enter a valid payment amount.", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentAmount.Focus();
                return;
            }

            if (paymentAmount <= 0)
            {
                MessageBox.Show("Payment amount must be greater than zero.", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentAmount.Focus();
                return;
            }

            if (paymentAmount > _selectedDebt.Outstanding)
            {
                MessageBox.Show("Payment amount cannot exceed the outstanding balance.", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentAmount.Focus();
                return;
            }

            try
            {
                _repository.AddPayment(new DebtPayment
                {
                    DebtId = _selectedDebt.Id,
                    PaymentAmount = paymentAmount,
                    PaymentDate = dtpPaymentDate.Value.Date
                });

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private string FormatCurrency(decimal amount)
        {
            if (amount < 0)
                return "-৳ " + Math.Abs(amount).ToString("N2");

            return "৳ " + amount.ToString("N2");
        }

        private class DebtComboItem
        {
            public Debt Debt { get; private set; }

            public DebtComboItem(Debt debt)
            {
                Debt = debt;
            }

            public override string ToString()
            {
                return Debt.Name + " — Outstanding: ৳ " + Debt.Outstanding.ToString("N2");
            }
        }
    }
}
