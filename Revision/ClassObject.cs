using System;
namespace ClassObject{
    class BankCustomer{
    public int CustomerId;
    public string Name;
    public decimal Balance;
    }
    class Progarm
    {
        public static void Main()
        {
            BankCustomer ob=new BankCustomer();
            ob.CustomerId=1;
            ob.Name="Anuska";
            ob.Balance=150000;
            Console.WriteLine($" This id is {ob.CustomerId} with name {ob.Name} and balance {ob.Balance}");
        }
    }
}