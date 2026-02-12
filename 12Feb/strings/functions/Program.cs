using System;
class Program
{
    static void Main()
    {
        // //extract digits and convert to an integer array.
        // string a="AB12C03Z9";
        // List<int> arr=new List<int>();
        // int k=0;
        // for(int i=0;i< a.Length; i++)
        // {
        //     if (char.IsDigit(a[i]))
        //     {
        //         arr.Add(a[i] - '0');
        //     }
        // }
        // foreach(var i in arr)
        // {
        //  Console.WriteLine(i);   
        // }
        //Validate that a password contains at least 5 alphabetic characters.
        string b= "pollu@45ai5//";
        int c=0;
        for(int i=0;i< b.Length; i++)
        {
            if (char.IsLetter(b[i])) ;
            {
                c++;
            }
        }
        if (c >= 5)
        {
            Console.WriteLine("Valid Password");
        }
        else
        {
             Console.WriteLine("not Valid Password");
        }
    }
}