using System;

class ATM
{
    public static void Run()
    {
        try
        {
            //input parse
            Console.Write("Card Inserted (yes/no): ");
            string Card = Console.ReadLine();
            //conditions statements

            if (Card == "yes")
            {
                Console.Write("Enter PIN: ");
                int Pin = int.Parse(Console.ReadLine());

                if (Pin == 1234)
                {
                    Console.Write("Enter Balance: ");
                    int Balance = int.Parse(Console.ReadLine());

                    if (Balance >= 1000)
                        Console.WriteLine("Withdrawal Successful");
                    else
                        Console.WriteLine("Insufficient Balance");
                }
                else
                    Console.WriteLine("Invalid PIN");
            }
            else
                Console.WriteLine("Insert Card");
        }

        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
