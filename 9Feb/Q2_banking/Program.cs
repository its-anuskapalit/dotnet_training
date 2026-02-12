using System;

namespace Q2
{
    public class BankAccount
    {
        private double Balance;

        public BankAccount(double balance)
        {
            Balance = balance;
        }

        public void Deposit(double amt)
        {
            if (amt > 0)
            {
                Balance += amt;
            }
        }

        public void Withdraw(double amt)
        {
            if (amt > 0 && amt <= Balance)
            {
                Balance -= amt;
            }
        }

        public double GetBalance()
        {
            return Balance;
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount(1000);

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Transaction {i} (D/W amount):");

                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                string[] parts = input.Split(' ');
                char type = parts[0][0];
                double amount = Convert.ToDouble(parts[1]);

                if (type == 'D')
                {
                    account.Deposit(amount);
                }
                else if (type == 'W')
                {
                    account.Withdraw(amount);
                }
            }

            Console.WriteLine("Final Balance: " + account.GetBalance());
        }
    }
}
