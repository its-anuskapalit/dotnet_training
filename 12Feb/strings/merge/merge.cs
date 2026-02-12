using System;

class Program
{
    static void Merge(int[] arr1, int[] arr2)
    {
        int i = 0, j = 0, k = 0;
        int[] result = new int[arr1.Length + arr2.Length];

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] < arr2[j])
            {
                result[k++] = arr1[i++];
            }
            else
            {
                result[k++] = arr2[j++];
            }
        }

        while (i < arr1.Length)
            result[k++] = arr1[i++];

        while (j < arr2.Length)
            result[k++] = arr2[j++];

        Console.WriteLine("Merged Array:");
        foreach (int num in result)
            Console.Write(num + " ");
    }

    static void Main()
    {
        Console.WriteLine("Enter size of arr1:");
        int size1 = int.Parse(Console.ReadLine());
        int[] arr1 = new int[size1];

        Console.WriteLine("Enter elements of arr1:");
        for (int i = 0; i < size1; i++)
            arr1[i] = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter size of arr2:");
        int size2 = int.Parse(Console.ReadLine());
        int[] arr2 = new int[size2];

        Console.WriteLine("Enter elements of arr2:");
        for (int i = 0; i < size2; i++)
            arr2[i] = int.Parse(Console.ReadLine());
        Array.Sort(arr1);
        Array.Sort(arr2);
        Merge(arr1, arr2);
    }
}
