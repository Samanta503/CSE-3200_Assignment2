using System;

namespace PersonalFinanceTracker
{
    public class DebtPayment
    {
        public int Id { get; set; }
        public int DebtId { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
