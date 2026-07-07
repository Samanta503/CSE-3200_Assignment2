# Personal Finance Tracker with Debt Management Module

## Assignment 1: Finance Module
The Finance tab allows the user to add income and expense transactions. It shows Total Income, Total Expenses, and Net Balance. Transactions are stored in an in-memory `List<Transaction>` as required by Assignment 1.

## Assignment 2: Debt Tracker Module
The Debt Tracker tab extends the same application with debt management. The user can add debts, make partial or full payments, view outstanding balances, and see automatic status updates.

## UI Design
The application keeps the original Assignment 1 dark dashboard UI:
- Dark form background
- Dark input panels
- Blue primary buttons
- Red delete buttons
- Dark styled DataGridView
- Green positive values and red negative/debt values
- Finance and Debt Tracker tabs share the same visual language

## Features
- Add income or expense transactions
- Delete selected finance transaction
- Show finance summary
- Add debt records
- Validate interest rate between 0 and 100
- Store debt data in SQLite database
- Make partial or full debt payment through modal `DebtPaymentForm`
- Prevent payment greater than outstanding balance
- Auto-calculate outstanding balance
- Auto-calculate debt status: Pending, Overdue, Paid
- Highlight overdue rows
- Show Total Debt Outstanding, Total Owed to Me, and Net Debt Position

## Class Diagram

```text
+------------------+
| Transaction      |
+------------------+
| Date             |
| Type             |
| Category         |
| Amount           |
| Notes            |
+------------------+

+------------------+
| Debt             |
+------------------+
| Id               |
| Name             |
| Type             |
| OriginalAmount   |
| InterestRate     |
| AmountPaid       |
| DueDate          |
+------------------+
| Outstanding      |
| Status           |
+------------------+

+------------------+
| DebtPayment      |
+------------------+
| Id               |
| DebtId           |
| PaymentAmount    |
| PaymentDate      |
+------------------+

+----------------------+
| DebtRepository       |
+----------------------+
| InitializeDatabase() |
| AddDebt()            |
| GetAllDebts()        |
| GetDebtById()        |
| DeleteDebt()         |
| AddPayment()         |
| GetTotal...()        |
+----------------------+

+----------------------+
| DebtPaymentForm      |
+----------------------+
| ComboBox debts       |
| Payment amount input |
| Payment date input   |
+----------------------+
| ConfirmPayment()     |
+----------------------+
```

Relationship: `Debt 1 ---- many DebtPayment`.

## Database Design
SQLite database file: `finance_tracker.db`

### Debts table
- Id
- Name
- Type
- OriginalAmount
- InterestRate
- AmountPaid
- DueDate

### DebtPayments table
- Id
- DebtId
- PaymentAmount
- PaymentDate

## Payment Flow
1. User adds a debt.
2. Debt is saved in the database.
3. User selects a debt and clicks Make Payment.
4. Modal `DebtPaymentForm` opens using `ShowDialog()`.
5. User enters payment amount.
6. System validates that payment does not exceed outstanding balance.
7. Payment is saved and `AmountPaid` is updated.
8. Grid and summary refresh.

## Status Rules
- Outstanding = 0: Paid
- Due date passed and outstanding > 0: Overdue
- Otherwise: Pending

## Conclusion
The final application preserves the original Assignment 1 Finance Tracker and adds the Assignment 2 Debt Tracker module with database-backed debt records and modal payment handling.
