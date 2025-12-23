using System;
namespace Oops
{
    public class Account
    {
        public int AccountId{get; set;}
        public string? Name{get; set;}
        public string GetAccountDetails()
        {
            return $"The name of id is {AccountId} and name is {Name}";
        }
    }

    public class SalesAccount: Account
    {
        public int Salesinfo{get; set;}
        public string GetSaleAccountDetails()
        {
            String result="";
            result+=base.GetAccountDetails();
            result+="I am from sales derived class";
            return result;
        }
    }
     public class PurchaseAccount: Account
    {
        
        }
    public sealed class CreditCardAccount
    {
        
    }
    }
