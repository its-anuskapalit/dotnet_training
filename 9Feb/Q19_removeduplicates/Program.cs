using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 2, 3, 4, 3, 5 };
        int[] unique = new int[arr.Length];
        int count = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            bool found = false;

            for (int j = 0; j < count; j++)
            {
                if (unique[j] == arr[i])
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                unique[count++] = arr[i];
        }

        for (int i = 0; i < count; i++)
            Console.Write(unique[i] + " ");
    }
}
