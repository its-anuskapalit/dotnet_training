using System;
class Stock
{
    public event Action<string> OnPriceChanged;
    public void ChangePrice(string msg)
    {
        OnPriceChanged?.Invoke(msg);
    }
}
class Program
{
    static void Main()
    {
        Stock stock=new Stock();
       stock.OnPriceChanged += msg => Console.WriteLine("UI Updated: " + msg);
        stock.OnPriceChanged += msg => Console.WriteLine("Logged: " + msg);

        stock.ChangePrice("Price updated to 500");
    }
}