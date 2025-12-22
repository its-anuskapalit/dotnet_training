using System;
// EVEN ODD CHECK PROGRAM
class Even
{
    public static bool isEven(int num)
    {
        return num % 2 == 0;
    }
    // Interactive check method
    public static void check()
    {
        Console.WriteLine("Enter a number to check even or odd (q to quit)");
        string? checkNum = Console.ReadLine();
        int localNumber;
        // Loop until user decides to quit
        while (checkNum != "q" && checkNum != "Q")
        {
            if (int.TryParse(checkNum, out localNumber))
            {
                string checkResult = isEven(localNumber) ? "Even" : "Odd";
                Console.WriteLine(checkResult);
            }
            // Handle invalid input
            else
            {
                Console.WriteLine("Invalid input");
            }
            // Prompt for next input
            Console.WriteLine("Enter a number to check even or odd (q to quit)");
            checkNum = Console.ReadLine();
        }
    }
}
