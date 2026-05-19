using System;
namespace delegates
{
    delegate void Notify();
    class Program
    {
        static void SendEmail()
        {
            Console.WriteLine("Email sent");
        }
        static void Log()
        {
             Console.WriteLine("Log sent");
        }
        static void Main()
        {
            Notify n= SendEmail;
            n+=Log;
            n();
        }
    }
}