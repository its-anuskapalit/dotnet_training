using Project;
class Program
{
    static void Main()
    {
        BankAccount acc=new SavingsAccount();
        acc.AccountNo=1001;
       ConsolerLogger logger=new ConsolerLogger();
        TransactionHistory h=new TransactionHistory();

        acc.Deposit(5000);
        logger.Log("Deposited 5000");
        h[0]="Deposit 5000";

        acc.Withdraw(2000);
        logger.Log("Withdrawn 2000");
        h[1]="Withdraw 2000";

        Console.WriteLine("Balance:"+acc.GetBalance());
        Console.WriteLine("History:"+h[0]+" , "+h[1]);
    }
}
