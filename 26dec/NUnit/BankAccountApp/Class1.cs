using System;

namespace BankAccountCore
{
    public class Program
    {
        // Property to store account balance
        public decimal Balance { get; private set; }

        // Constructor to initialize balance
        public Program(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        // Method to deposit amount into the account
        public void Deposit(decimal amount)
        {
            // Check for negative deposit
            if (amount < 0)
            {
                throw new Exception("Deposit amount cannot be negative");
            }

            // Add amount to balance
            Balance += amount;
        }

        // Method to withdraw amount from the account
        public void Withdraw(decimal amount)
        {
            // Check for insufficient balance
            if (amount > Balance)
            {
                throw new Exception("Insufficient funds.");
            }

            // Deduct amount from balance
            Balance -= amount;
        }
    }
}
