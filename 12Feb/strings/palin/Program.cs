using System;
class Program
{
    static bool Palim(string input)
    {
        bool result=false;
        int i=0;
        int j= input.Length-1;
        while (i < j)
        {
            if (input[i] == input[j])
            {
                result=true;
            }
            else
            {
                result = false;
            }
            i++;
            j--;
        }
        return result;
    }
    static void Main()
    {
        string input=Console.ReadLine();
        var result =Palim(input);
        Console.WriteLine(result);
    }
}