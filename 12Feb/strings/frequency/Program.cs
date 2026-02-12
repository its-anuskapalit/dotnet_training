using System;
class Program
{
    static void Main()
    {
         Console.WriteLine("Enter size");
        int size= int.Parse(Console.ReadLine());
        Console.WriteLine("Enter elements");
        int[] arr=new int[5];
        for(int i = 0; i < size; i++)
        {
            arr[i]=int.Parse(Console.ReadLine());
        }
        Dictionary<int,int> output=new Dictionary<int, int>();
        foreach(var i in arr)
        {
            if (output.ContainsKey(i))
            {
                output[i]++;
            }
            else
            {
                output[i]=1;
            }
        }
        foreach(var i in output)
        {
            Console.WriteLine(i);
        }

    }
}