using System;

class GotoSearch
{
    public static void Run()
    {
        try
        {
            int[,] Matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int Target = 5;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Matrix[i, j] == Target)
                        goto Found;
                }
            }

            Console.WriteLine("Not Found");
            return;

        Found:
            Console.WriteLine("Element Found");
        }
        catch (Exception Ex)
        {
            Console.WriteLine("Error: " + Ex.Message);
        }
    }
}
