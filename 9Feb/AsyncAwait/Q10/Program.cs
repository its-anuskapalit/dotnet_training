using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        try
        {
            await Task.WhenAll(Fail(), Fail(), Success());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static async Task Fail()
    {
        await Task.Delay(200);
        throw new Exception("Error");
    }

    static async Task Success()
    {
        await Task.Delay(300);
    }
}
