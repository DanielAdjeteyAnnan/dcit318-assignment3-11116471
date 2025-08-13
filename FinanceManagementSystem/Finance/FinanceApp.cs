using System;
using System.Collections.Generic;

namespace Finance
{
    public class FinanceApp
    {
        private readonly List<Transaction> _transactions = new();

        public void Run()
        {
            // i) instantiate savings account with initial balance GHC1000
            var account = new SavingsAccount("SA-001", 1000m);
            Console.WriteLine($"[Init] Account {account.AccountNumber} opened with balance GHC{account.Balance:N2}\n");

            // ii) create three transactions
            var t1 = new Transaction(1, DateTime.Now, 120m, "Groceries");
            var t2 = new Transaction(2, DateTime.Now, 300m, "Utilities");
            var t3 = new Transaction(3, DateTime.Now, 250m, "Entertainment");

            // iii) processors: MobileMoney -> t1, BankTransfer -> t2, CryptoWallet -> t3
            ITransactionProcessor p1 = new MobileMoneyProcessor();
            ITransactionProcessor p2 = new BankTransferProcessor();
            ITransactionProcessor p3 = new CryptoWalletProcessor();

            p1.Process(t1);
            p2.Process(t2);
            p3.Process(t3);

            Console.WriteLine();

            // iv) apply transactions to account
            account.ApplyTransaction(t1); // GHC120
            account.ApplyTransaction(t2); // GHC300
            account.ApplyTransaction(t3); // GHC250

            Console.WriteLine($"\n[Final Balance] {FormatGhc(account.Balance)}");

            // v) store transactions
            _transactions.AddRange(new[] { t1, t2, t3 });

            Console.WriteLine("\n[Transactions Recorded]");
            foreach (var tx in _transactions)
            {
                Console.WriteLine($"#{tx.Id} {tx.Category} - {FormatGhc(tx.Amount)} on {tx.Date:g}");
            }
        }

        private static string FormatGhc(decimal amount) => $"GHC{amount:N2}";
    }
}
