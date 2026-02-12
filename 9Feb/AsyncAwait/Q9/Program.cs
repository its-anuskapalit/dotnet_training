using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            await ErrorAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task ErrorAsync()
    {
        await Task.Delay(300);
        throw new Exception("Failed");
    }
}
