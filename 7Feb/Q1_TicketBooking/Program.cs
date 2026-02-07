using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        var bookingService = new TicketBookingService(new[] { 1 });

        var tasks = new List<Task>();

        for (int i = 1; i <= 5; i++)
        {
            var userId = $"User{i}";
            tasks.Add(Task.Run(() =>
            {
                var result = bookingService.BookSeat(1, userId);
                Console.WriteLine($"{userId} booking result: {result}");
            }));
        }

        Task.WaitAll(tasks.ToArray());
    }
}
