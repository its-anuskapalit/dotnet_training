using System;
// GUESS THE NUMBER GAME
class GuessingGame
{
    public static void Run()
    {
        try
        {
            //input parsing and game logic
            int SecretNumber = 7;
            int Guess;
            //loop until correct guess
            do
            {
                Console.Write("Guess the Number: ");
                Guess = int.Parse(Console.ReadLine());
            }
            while (Guess != SecretNumber);

            Console.WriteLine("Correct Guess!");
        }
        //error catching
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
