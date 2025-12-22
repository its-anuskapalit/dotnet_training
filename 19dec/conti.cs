using System;
// CONTINUE STATEMENT PROGRAM
class continueprogram
{
    public static void Usage()
    {
        //print numbers from 1 to 50 except multiples of 3
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
            {
                continue;
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}
