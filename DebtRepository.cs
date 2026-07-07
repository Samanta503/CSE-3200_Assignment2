using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Data.Sqlite;

namespace PersonalFinanceTracker
{
    public class DebtRepository
    {
        private readonly string _dbPath;
        private readonly string _connectionString;

        public DebtRepository()
        {
            _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "finance_tracker.db");
            _connectionString = "Data Source=" + _dbPath;
        }

        public void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var pragma = connection.CreateCommand())
                {
                    pragma.CommandText = "PRAGMA foreign_keys = ON;";
                    pragma.ExecuteNonQuery();
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS Debts (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Name TEXT NOT NULL,
                            Type TEXT NOT NULL,
                            OriginalAmount REAL NOT NULL,
                            InterestRate REAL NOT NULL,
                            AmountPaid REAL NOT NULL DEFAULT 0,
                            DueDate TEXT NOT NULL
                        );";
                    command.ExecuteNonQuery();
                }

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        CREATE TABLE IF NOT EXISTS DebtPayments (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            DebtId INTEGER NOT NULL,
                            PaymentAmount REAL NOT NULL,
                            PaymentDate TEXT NOT NULL,
                            FOREIGN KEY(DebtId) REFERENCES Debts(Id)
                        );";
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddDebt(Debt debt)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        INSERT INTO Debts 
                        (Name, Type, OriginalAmount, InterestRate, AmountPaid, DueDate)
                        VALUES 
                        (@Name, @Type, @OriginalAmount, @InterestRate, @AmountPaid, @DueDate);";

                    command.Parameters.AddWithValue("@Name", debt.Name);
                    command.Parameters.AddWithValue("@Type", debt.Type);
                    command.Parameters.AddWithValue("@OriginalAmount", debt.OriginalAmount);
                    command.Parameters.AddWithValue("@InterestRate", debt.InterestRate);
                    command.Parameters.AddWithValue("@AmountPaid", debt.AmountPaid);
                    command.Parameters.AddWithValue("@DueDate", debt.DueDate.ToString("yyyy-MM-dd"));

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Debt> GetAllDebts()
        {
            var debts = new List<Debt>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT Id, Name, Type, OriginalAmount, InterestRate, AmountPaid, DueDate
                        FROM Debts
                        ORDER BY Id DESC;";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            debts.Add(new Debt
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Type = reader["Type"].ToString(),
                                OriginalAmount = Convert.ToDecimal(reader["OriginalAmount"]),
                                InterestRate = Convert.ToDecimal(reader["InterestRate"]),
                                AmountPaid = Convert.ToDecimal(reader["AmountPaid"]),
                                DueDate = DateTime.Parse(reader["DueDate"].ToString())
                            });
                        }
                    }
                }
            }

            return debts;
        }

        public Debt GetDebtById(int id)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT Id, Name, Type, OriginalAmount, InterestRate, AmountPaid, DueDate
                        FROM Debts
                        WHERE Id = @Id;";

                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Debt
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Type = reader["Type"].ToString(),
                            OriginalAmount = Convert.ToDecimal(reader["OriginalAmount"]),
                            InterestRate = Convert.ToDecimal(reader["InterestRate"]),
                            AmountPaid = Convert.ToDecimal(reader["AmountPaid"]),
                            DueDate = DateTime.Parse(reader["DueDate"].ToString())
                        };
                    }
                }
            }
        }

        public void DeleteDebt(int debtId)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var deletePayments = connection.CreateCommand())
                    {
                        deletePayments.Transaction = transaction;
                        deletePayments.CommandText = "DELETE FROM DebtPayments WHERE DebtId = @DebtId;";
                        deletePayments.Parameters.AddWithValue("@DebtId", debtId);
                        deletePayments.ExecuteNonQuery();
                    }

                    using (var deleteDebt = connection.CreateCommand())
                    {
                        deleteDebt.Transaction = transaction;
                        deleteDebt.CommandText = "DELETE FROM Debts WHERE Id = @DebtId;";
                        deleteDebt.Parameters.AddWithValue("@DebtId", debtId);
                        deleteDebt.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public void AddPayment(DebtPayment payment)
        {
            Debt debt = GetDebtById(payment.DebtId);

            if (debt == null)
                throw new InvalidOperationException("Selected debt record was not found.");

            if (payment.PaymentAmount <= 0)
                throw new InvalidOperationException("Payment amount must be greater than zero.");

            if (payment.PaymentAmount > debt.Outstanding)
                throw new InvalidOperationException("Payment amount cannot exceed the outstanding balance.");

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    using (var insertPayment = connection.CreateCommand())
                    {
                        insertPayment.Transaction = transaction;
                        insertPayment.CommandText = @"
                            INSERT INTO DebtPayments 
                            (DebtId, PaymentAmount, PaymentDate)
                            VALUES 
                            (@DebtId, @PaymentAmount, @PaymentDate);";

                        insertPayment.Parameters.AddWithValue("@DebtId", payment.DebtId);
                        insertPayment.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                        insertPayment.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate.ToString("yyyy-MM-dd"));

                        insertPayment.ExecuteNonQuery();
                    }

                    using (var updateDebt = connection.CreateCommand())
                    {
                        updateDebt.Transaction = transaction;
                        updateDebt.CommandText = @"
                            UPDATE Debts
                            SET AmountPaid = AmountPaid + @PaymentAmount
                            WHERE Id = @DebtId;";

                        updateDebt.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                        updateDebt.Parameters.AddWithValue("@DebtId", payment.DebtId);

                        updateDebt.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public decimal GetTotalDebtOutstanding()
        {
            decimal total = 0m;

            foreach (var debt in GetAllDebts())
            {
                if (debt.Type == "I Owe")
                    total += debt.Outstanding;
            }

            return total;
        }

        public decimal GetTotalOwedToMe()
        {
            decimal total = 0m;

            foreach (var debt in GetAllDebts())
            {
                if (debt.Type == "Owed to Me")
                    total += debt.Outstanding;
            }

            return total;
        }

        public decimal GetNetDebtPosition()
        {
            return GetTotalOwedToMe() - GetTotalDebtOutstanding();
        }
    }
}