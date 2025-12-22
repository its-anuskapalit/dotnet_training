using System;
// ACCOUNT AND SALESACCOUNT CLASSES USING INHERITANCE
namespace Oops
{
    // Base Account class
    public class Account
    {
        // Properties
        public int AccountId{get; set;}
        public string? Name{get; set;}
        public string GetAccountDetails()
        {
            return $"The name of id is {AccountId} and name is {Name}";
        }
    }
    // Derived SalesAccount class
    public class SalesAccount: Account
    {
        // Additional Property
        public int Salesinfo{get; set;}
        public string GetSaleAccountDetails()
        {
            String result="";
            result+=base.GetAccountDetails();
            result+="I am from sales derived class";
            return result;
        }
    }
}