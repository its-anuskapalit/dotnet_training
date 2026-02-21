using System;
using System.Collections.Generic;
using System.Linq;
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}
public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message) { }
}
public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message) { }
}
public abstract class BankAccount
{
    public string AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; protected set; }
    protected BankAccount(string accNo, string name, decimal balance)
    {
        AccountNumber = accNo;
        CustomerName = name;
        Balance = balance;
    }
    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Invalid deposit amount");
        Balance += amount;
    }
    public virtual void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidTransactionException("Invalid withdrawal amount");

        if (amount > Balance)
            throw new InsufficientBalanceException("Insufficient balance");
        Balance -= amount;
    }
    public abstract decimal CalculateInterest();
}
public class SavingsAccount : BankAccount
{
    private const decimal MinBalance = 1000;
    private const decimal InterestRate = 0.04m;

    public SavingsAccount(string accNo, string name, decimal balance) : base(accNo, name, balance) { }
    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < MinBalance)
            throw new MinimumBalanceException("Minimum balance violation");
        base.Withdraw(amount);
    }
    public override decimal CalculateInterest()
    {
        return Balance * InterestRate;
    }
}

public class CurrentAccount : BankAccount
{
    private const decimal OverdraftLimit = 20000;
    public CurrentAccount(string accNo, string name, decimal balance) : base(accNo, name, balance) { }

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < -OverdraftLimit)
            throw new InsufficientBalanceException("Overdraft limit exceeded");

        Balance -= amount;
    }
    public override decimal CalculateInterest()
    {
        return 0;
    }
}
public class LoanAccount : BankAccount
{
    private const decimal InterestRate = 0.08m;
    public LoanAccount(string accNo, string name, decimal loanAmount) : base(accNo, name, -loanAmount) { }

    public override void Deposit(decimal amount)
    {
        throw new InvalidTransactionException("Cannot deposit into loan account");
    }
    public override decimal CalculateInterest()
    {
        return Math.Abs(Balance) * InterestRate;
    }
}
class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>
        {
            new SavingsAccount("SA101", "Rohan", 60000),
            new SavingsAccount("SA102", "Amit", 20000),
            new CurrentAccount("CA201", "Riya", 80000),
            new CurrentAccount("CA202", "Karan", 15000),
            new LoanAccount("LA301", "Raj", 50000)
        };
        Console.WriteLine("Accounts with balance > 50000:");
        var highBalance = accounts.Where(a => a.Balance > 50000);
        foreach (var acc in highBalance)
            Console.WriteLine($"{acc.CustomerName} - {acc.Balance}");
        Console.WriteLine("\nTotal Bank Balance:");
        var total = accounts.Sum(a => a.Balance);
        Console.WriteLine(total);
        Console.WriteLine("\nTop 3 Highest Balance Accounts:");
        var top3 = accounts.OrderByDescending(a => a.Balance).Take(3);
        foreach (var acc in top3)
            Console.WriteLine($"{acc.CustomerName} - {acc.Balance}");
        Console.WriteLine("\nGroup By Account Type:");
        var grouped = accounts.GroupBy(a => a.GetType().Name);
        foreach (var group in grouped)
        {
            Console.WriteLine(group.Key);
            foreach (var acc in group)
                Console.WriteLine($"  {acc.CustomerName} - {acc.Balance}");
        }
        Console.WriteLine("\nCustomers starting with 'R':");
        var rCustomers = accounts.Where(a => a.CustomerName.StartsWith("R"));
        foreach (var acc in rCustomers)
            Console.WriteLine(acc.CustomerName);
    }
}
