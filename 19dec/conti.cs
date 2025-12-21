using System;
    class conti
{
    public static void Usage()
    {
        for(int i = 1; i <= 50; i++)
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
