using System;

class GuessingGame
{
    public static void Run()
    {
        try
        {
            int SecretNumber = 7;
            int Guess;

            do
            {
                Console.Write("Guess the Number: ");
                Guess = int.Parse(Console.ReadLine());
            }
            while (Guess != SecretNumber);

            Console.WriteLine("Correct Guess!");
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
