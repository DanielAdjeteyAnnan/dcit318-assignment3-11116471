using System;

namespace Finance
{
    // b) processor interface
    public interface ITransactionProcessor
    {
        void Process(Transaction transaction);
    }

    // c) three concrete processors
    public class BankTransferProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[BankTransfer] Processing {FormatGhc(transaction.Amount)} for {transaction.Category}");
        }

        private static string FormatGhc(decimal amount) => $"GHC{amount:N2}";
    }

    public class MobileMoneyProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[MobileMoney] Processing {FormatGhc(transaction.Amount)} for {transaction.Category}");
        }

        private static string FormatGhc(decimal amount) => $"GHC{amount:N2}";
    }

    public class CryptoWalletProcessor : ITransactionProcessor
    {
        public void Process(Transaction transaction)
        {
            Console.WriteLine($"[CryptoWallet] Processing {FormatGhc(transaction.Amount)} for {transaction.Category}");
        }

        private static string FormatGhc(decimal amount) => $"GHC{amount:N2}";
    }
}
