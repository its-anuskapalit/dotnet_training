namespace OopsBasic{
public class Account
{
    public int Balance;
}
public class Program{
    static void Main()
{
    Account a1 = new Account();
    a1.Balance=500;
    Account a2=a1;
    Console.WriteLine(a2.Balance);
}
}
}