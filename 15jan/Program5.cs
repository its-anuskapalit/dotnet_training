using System;
namespace Q5
{
    public class EcommerceShop
    {
        public string UserName;
        public double WalletBalance;
        public double TotalPurchaseAmount;
    }

    public class InsufficientWalletBalanceException : Exception
    {
        public InsufficientWalletBalanceException(string message) : base(message) { }
    }
    class Program
    {
        public static EcommerceShop MakePayment(string name, double balance, double amount)
        {
            if (balance < amount)
                throw new InsufficientWalletBalanceException("Insufficient balance in your digital wallet");

            EcommerceShop shop = new EcommerceShop();
            shop.UserName = name;
            shop.WalletBalance = balance - amount;
            shop.TotalPurchaseAmount = amount;

            return shop;
        }
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Wallet Balance:");
                double balance = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Purchase Amount:");
                double amount = double.Parse(Console.ReadLine());

                EcommerceShop shop = MakePayment(name, balance, amount);
                Console.WriteLine("Payment successful");
            }
            catch (InsufficientWalletBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
