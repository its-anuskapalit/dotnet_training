using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace fetch
{
    class Program
    {
        static void Main()
        {
           Program p = new Program();

            Thread t1 = new Thread(() =>
            {
                p.Run().GetAwaiter().GetResult();
            });

            t1.Start();
            t1.Join();
        }
        public static async Task AsyncMethod()
        {
            Console.WriteLine("Tast started");
            await Task.Delay(3000);
            Console.WriteLine("Task completed after 3sec");
        }

        async Task Run()
        {
            string data = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
            Console.WriteLine(data);
            await AsyncMethod();
        }

        async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                return response;
            }
        }
    }
}
