//virtual allows a method to be overriden 
class Payment
{
    public virtual void Process()
    {
        Console.WriteLine("Processing payment");
    }
}
class CardPayment: Payment
{
    public override void Process()
    {
        Console.WriteLine("Processing card payment");
    }
}
class UpiPayment : Payment
{
    public override void Process()
    {
        Console.WriteLine("Processing UPI payment");
    }
}