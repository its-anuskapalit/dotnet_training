using System;
class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message): base(message)
    {
    }
}
class InvalidAmountException  : Exception
{
    public InvalidAmountException (string message): base(message){}
}
class BankAcc
{
    public double Balance{get;set;}
    public BankAcc(double balance)
    {
        Balance=balance;
    }
    public void Withdraw(double amt)
    {
        if (amt <= 0)
        {
            throw new InvalidAmountException("amt more than zero");
        }
        if(amt > Balance)
        {
            throw new InsufficientBalanceException("Amt cannot be more than balance");
        }
        Balance-=amt;
    }
}
class Program
{
    static void Main()
    {
        BankAcc bank=new BankAcc(5000);
        try
        {
            bank.Withdraw(000);
        }
        catch (InvalidAmountException ex)
        {
            Console.WriteLine("Validation Error: " + ex.Message);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine("Business Error: " + ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine("System Error: "+ex.Message);
        }
        finally
        {
            Console.WriteLine("Transaction Completed.");
        }
    }
}