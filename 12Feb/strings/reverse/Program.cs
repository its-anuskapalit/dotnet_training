using System;
class Program
{
    static string Reverse(string input)
    {
        string result="";
        for(int i = input.Length - 1; i >= 0; i--)
        {
            result+= input[i];
        }
        return result;
    }
    static void Main()
    {
        string input=Console.ReadLine();
        Console.WriteLine( Reverse(input));
    }
}