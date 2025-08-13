using System;

namespace Finance
{
    // immutable record for transaction
    public record Transaction(int Id, DateTime Date, decimal Amount, string Category);

    // d) Base class Account
    public class Account
    {
        public string AccountNumber { get; }
        public decimal Balance { get; protected set; }

        public Account(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber)) throw new ArgumentNullException(nameof(accountNumber));
            if (initialBalance < 0) throw new ArgumentOutOfRangeException(nameof(initialBalance), "Initial balance cannot be negative.");

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        // virtual deduction behavior
        public virtual void ApplyTransaction(Transaction transaction)
        {
            if (transaction is null) throw new ArgumentNullException(nameof(transaction));
            Balance -= transaction.Amount;
            Console.WriteLine($"[Account] Applied {FormatGhc(transaction.Amount)}. New balance: {FormatGhc(Balance)}");
        }

        protected static string FormatGhc(decimal amount) => $"GHC{amount:N2}";
    }

    // e) sealed SavingsAccount with override
    public sealed class SavingsAccount : Account
    {
        public SavingsAccount(string accountNumber, decimal initialBalance)
            : base(accountNumber, initialBalance) { }

        public override void ApplyTransaction(Transaction transaction)
        {
            if (transaction is null) throw new ArgumentNullException(nameof(transaction));

            if (transaction.Amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            Balance -= transaction.Amount;
            Console.WriteLine($"[SavingsAccount] Deducted {FormatGhc(transaction.Amount)}. Updated balance: {FormatGhc(Balance)}");
        }
    }
}
