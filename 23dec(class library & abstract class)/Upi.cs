using System;
namespace Oops
{
abstract class Payment
{
    public decimal Amount { get; }
    protected Payment(decimal amount) => Amount = amount;

    public void PrintReceipt()
    {
        Console.WriteLine($"Receipt: Amount={Amount}");
    }

    public abstract void Pay(); // must be implemented
}

class UpiPayment : Payment
{
    public string UpiId { get; }
    public UpiPayment(decimal amount, string upiId) : base(amount) => UpiId = upiId;

    public override void Pay()
    {
        Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
    }
}
}
