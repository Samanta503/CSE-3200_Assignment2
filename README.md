# CSE-3200 Assignment 2 — Personal Finance Tracker

## Project
C# Windows Forms application with:
- Assignment 1 Finance Tracker
- Assignment 2 Debt Tracker

## Framework
.NET Framework 4.7.2 Windows Forms

## NuGet Package
- System.Data.SQLite.Core

## How to Run
1. Open `PersonalFinanceTracker.sln` in Visual Studio.
2. Right-click solution and choose **Restore NuGet Packages**.
3. Build the solution.
4. Run the project.
5. To run the project use this command dotnet run --project .\PersonalFinanceTracker.csproj

## Database
Debt data is stored in a local SQLite database:
`finance_tracker.db`

The database is created automatically when the app starts.

## Main Features
- Add income and expense transactions
- Show Total Income, Total Expenses, Net Balance
- Add debt records
- Store debts in SQLite database
- Make partial/full debt payments
- Auto-update outstanding balance
- Auto-calculate Pending, Overdue, Paid status
- Highlight overdue debts
- Show debt summary
