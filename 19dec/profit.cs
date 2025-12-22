using System;

class ProfitLoss
{
    public static void Run()
    {
        try
        {
            Console.Write("Cost Price: ");
            double CostPrice = double.Parse(Console.ReadLine());

            Console.Write("Selling Price: ");
            double SellingPrice = double.Parse(Console.ReadLine());

            if (SellingPrice > CostPrice)
            {
                double Profit = ((SellingPrice - CostPrice) / CostPrice) * 100;
                Console.WriteLine("Profit %: " + Profit);
            }
            else
            {
                double Loss = ((CostPrice - SellingPrice) / CostPrice) * 100;
                Console.WriteLine("Loss %: " + Loss);
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
