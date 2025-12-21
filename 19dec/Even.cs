using System;
class Even
{
    public static bool isEven(int num)
    {
        return num % 2 == 0;
    }
    public static void check()
    {
        Console.WriteLine("Enter a number to check even or odd (q to quit)");
        string? checkNum = Console.ReadLine();
        int localNumber;
        while (checkNum != "q" && checkNum != "Q")
        {
            if (int.TryParse(checkNum, out localNumber))
            {
                string checkResult = isEven(localNumber) ? "Even" : "Odd";
                Console.WriteLine(checkResult);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine("Enter a number to check even or odd (q to quit)");
            checkNum = Console.ReadLine();
        }
    }
}
