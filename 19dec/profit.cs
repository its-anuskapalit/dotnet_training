using System;
// PROFIT AND LOSS CALCULATION PROGRAM
class ProfitLoss
{
    public static void Run()
    {
        //input parsing
        try
        {
            Console.Write("Cost Price: ");
            double CostPrice = double.Parse(Console.ReadLine());

            Console.Write("Selling Price: ");
            double SellingPrice = double.Parse(Console.ReadLine());
            //calculate profit or loss
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
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
