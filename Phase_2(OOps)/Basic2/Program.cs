//encapsulation
using System;
namespace Basic
{
    class Account
    {
        private int balance ;
        public Account(int initial)
        {
            this.balance=initial;
        }

        public void Desposit(int amount)
        {
            if(amount <=0 ) return;
            balance+=amount;
        }
        public int GetBalance()
        {
            return balance;
        }
    }
    class Program
    {
        static void Main()
        {
            Account account=new Account (500);
            account.Desposit(200);
            Console.WriteLine(account.GetBalance());
        }
    }
}