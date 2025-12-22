using System;
// PASCAL'S TRIANGLE PROGRAM
class pascal
{
    public static void Display()
    {
        //input parsing
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];
        //generate Pascal's Triangle
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                //first and last element of each row is 1
                if (j == 0 || j == i)
                    arr[i, j] = 1;
                else
                    arr[i, j] = arr[i - 1, j - 1] + arr[i - 1, j];

                Console.Write(arr[i, j] + " ");
            }
     
            Console.WriteLine();
        }
    }
}
