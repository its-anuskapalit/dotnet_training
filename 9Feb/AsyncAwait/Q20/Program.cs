using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var urls = new[]
        {
            "https://example.com",
            "https://example.com",
            "https://example.com",
            "https://example.com",
            "https://example.com"
        };

        using var client = new HttpClient();

        var tasks = new Task<string>[urls.Length];
        for (int i = 0; i < urls.Length; i++)
            tasks[i] = client.GetStringAsync(urls[i]);

        var results = await Task.WhenAll(tasks);

        foreach (var r in results)
            Console.WriteLine(r.Length);
    }
}
