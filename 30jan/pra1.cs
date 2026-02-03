using System;
namespace Q1{
class Program
{
    static void Main()
    {
        int[] marks = { 35, 40, 45 };

        Func<int[], int> calculateAverage = m =>
        {
            int sum = 0;
            foreach (var x in m)
                sum += x;
            return sum / m.Length;
        };

        Predicate<int> isFail = avg => avg < 40;

        Action<int> showResult = avg =>
        {
            if (avg < 40)
                Console.WriteLine("Fail");
            else
                Console.WriteLine("Pass");
        };

        int average = calculateAverage(marks);

        Console.WriteLine("Average: " + average);

        if (isFail(average))
            Console.WriteLine("Needs Improvement");

        showResult(average);
    }
}
}