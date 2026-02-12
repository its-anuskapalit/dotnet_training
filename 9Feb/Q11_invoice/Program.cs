using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        double grandTotal = 0;

        for (int i = 1; i <= 5; i++)
        {
            string item = "Item" + i;
            int qty = i;
            double price = i * 100;
            double total = qty * price;
            grandTotal += total;

            sb.AppendLine($"{item}\t{qty}\t{price}\t{total}");
        }

        sb.AppendLine("------------------------");
        sb.AppendLine("Grand Total: " + grandTotal);
        Console.WriteLine(sb.ToString());
    }
}
