using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(300);
                throw new Exception();
            }
            catch
            {
                Console.WriteLine("Logged");
            }
        });

        Console.ReadLine();
    }
}
