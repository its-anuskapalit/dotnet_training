using System;
namespace DesignContracts
{
    interface IAuditable
    {
        void Audit();
    }
    abstract class Transaction
    {
        private readonly Guid id;
        protected Transaction()
        {
            id=Guid.NewGuid();
        }
        public void Execute()
        {
            Validate();
            Perform();
            Complete();
        }
        protected virtual void Validate()
        {
            
        }
        protected abstract void Perform();
        private void Complete()
        {
             Console.WriteLine($"Transaction {id} completed");
        }
    }
    class BankTransfer: Transaction, IAuditable
    {
        protected override void Perform()
        {
            Console.WriteLine("Performing bank transfer");
        }
        public void Audit()
        {
            Console.WriteLine("Auditing bank transfer");
        }
    }
    class WalletPayment: Transaction
    {
        protected override void Validate()
        {
            Console.WriteLine("Wallet validation");
        }
        protected override void Perform()
        {
            Console.WriteLine("Performing wallet payment");
        }
    }
    class Program
    {
        static void Main()
        {
            List<Transaction> transactions = new()
            {
                new BankTransfer(),
                new WalletPayment()
            };

            foreach (var t in transactions)
            {
                t.Execute();

                if (t is IAuditable audit)
                {
                    audit.Audit();
                }
            }
        }
    }
}