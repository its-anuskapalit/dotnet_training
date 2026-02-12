using System;
class Program
{
    static void Main()
    {
        int[] arr = { 10, 20, 30, 40, 50 };
        int k = 2;
        int n = arr.Length;

        k = k % n;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
            result[(i + k) % n] = arr[i];

        for (int i = 0; i < n; i++)
            Console.Write(result[i] + " ");
    }
}
