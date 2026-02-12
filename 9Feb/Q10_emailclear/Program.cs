using System;
namespace Q10
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter your email: ");
            string email=Console.ReadLine();
            email=email.Trim().ToLower();
            email=email.Replace("@gmail.com","@company.com");
            Console.WriteLine(email);
        }
    }
}