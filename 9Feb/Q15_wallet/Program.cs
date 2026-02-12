using System;
namespace Q15
{
    class Program
    {
        static void Main()
        {
            double balance = 1000;
            double amount = 250;

            MakePayment(ref balance, amount);

            Console.WriteLine("Updated Balance: " + balance);
            
        }
        static void MakePayment(ref double walletBalance, double amount)
        {
            if(amount > 0 && amount <= walletBalance)
            {
                walletBalance-=amount;
            }
            
        }
    }
}