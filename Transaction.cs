// Transaction.cs
// Represents a single financial transaction in the Personal Finance Tracker.
// This is a plain data model class — no UI logic here.

using System;

namespace PersonalFinanceTracker
{
    /// <summary>
    /// Represents one financial transaction (either Income or Expense).
    /// </summary>
    public class Transaction
    {
        /// <summary>The date the transaction occurred.</summary>
        public DateTime Date { get; set; }

        /// <summary>Transaction type: "Income" or "Expense".</summary>
        public string Type { get; set; }

        /// <summary>Category of the transaction (e.g., Salary, Food, Transport).</summary>
        public string Category { get; set; }

        /// <summary>Monetary amount of the transaction (always positive).</summary>
        public decimal Amount { get; set; }

        /// <summary>Optional free-text notes about the transaction.</summary>
        public string Notes { get; set; }

        /// <summary>
        /// Parameterised constructor for easy object initialisation.
        /// </summary>
        public Transaction(DateTime date, string type, string category, decimal amount, string notes)
        {
            Date     = date;
            Type     = type;
            Category = category;
            Amount   = amount;
            Notes    = notes ?? string.Empty;
        }
    }
}
