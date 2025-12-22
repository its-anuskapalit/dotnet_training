using System;
// ACCOUNT AND SALESACCOUNT PROGRAM
namespace Oops
{
    // Base class
    class CallAcc
{
    public static void Main()
    {
            // Creating object of Account class
         Account acc =new Account(){ AccountId=1,Name="Anuska"};
        string result=acc.GetAccountDetails();
        Console.WriteLine(result);
            // Creating object of SalesAccount class

            SalesAccount acc2 = new SalesAccount(){AccountId=2,Name="Polly", Salesinfo=100};
        String result2=acc2.GetSaleAccountDetails();
        Console.WriteLine(result2);

        
    }
}
}