using System;

class Program
{
    static void Main()
    {
        int[] sales = new int[7];
        int sum = 0, max, min, maxDay = 0;

        for (int i = 0; i < 7; i++)
        {
            sales[i] = int.Parse(Console.ReadLine());
            sum += sales[i];
        }

        max = min = sales[0];

        for (int i = 1; i < 7; i++)
        {
            if (sales[i] > max)
            {
                max = sales[i];
                maxDay = i;
            }
            if (sales[i] < min)
                min = sales[i];
        }

        Console.WriteLine("Highest: " + max);
        Console.WriteLine("Lowest: " + min);
        Console.WriteLine("Average: " + (sum / 7.0));
        Console.WriteLine("Highest Sale Day Index: " + maxDay);
    }
}
