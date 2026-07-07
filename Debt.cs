using System;

namespace PersonalFinanceTracker
{
    public class Debt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // "I Owe" or "Owed to Me"
        public decimal OriginalAmount { get; set; }
        public decimal InterestRate { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }

        public decimal Outstanding
        {
            get
            {
                decimal value = OriginalAmount - AmountPaid;
                return value < 0 ? 0 : value;
            }
        }

        public string Status
        {
            get
            {
                if (Outstanding <= 0) return "Paid";
                if (DueDate.Date < DateTime.Today) return "Overdue";
                return "Pending";
            }
        }
    }
}
