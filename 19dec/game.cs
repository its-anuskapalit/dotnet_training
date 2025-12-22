using System;

class RockPaperScissors
{
    public static void Run()
    {
        try
        {
            Console.Write("Player 1 Choice: ");
            string Player1 = Console.ReadLine().ToLower();

            Console.Write("Player 2 Choice: ");
            string Player2 = Console.ReadLine().ToLower();

            if (Player1 == Player2)
                Console.WriteLine("Draw");
            else if ((Player1 == "rock" && Player2 == "scissors") ||
                     (Player1 == "scissors" && Player2 == "paper") ||
                     (Player1 == "paper" && Player2 == "rock"))
                Console.WriteLine("Player 1 Wins");
            else
                Console.WriteLine("Player 2 Wins");
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
