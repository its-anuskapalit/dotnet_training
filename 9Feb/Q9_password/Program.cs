using System;
namespace Q9
{
    class Program
    {
        static void Main()
        {
            string a="Welcome123";
            string password= MakePassWord(a);
            Console.WriteLine(password);
        }
        static string MakePassWord(string a)
        {
            string str="";
            str+=a[0];
            for(int i = 1; i < a.Length - 2; i++)
            {
                str+='*';
            }
            str+=a[a.Length-1];
            return str;
        }
    }
}