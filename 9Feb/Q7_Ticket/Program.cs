using System;
namespace Q7
{
    public class Ticket
    {
        static int LastTicketNo=1000;
        public int TicketNo;
        public Ticket()
        {
            LastTicketNo++;
            TicketNo=LastTicketNo;
        }
    }
    class Program
    {
        static void Main()
        {
            int n=5;
            Console.WriteLine("Ticket Numbers: ");
            for(int i = 0; i < n; i++)
            {
                Ticket t=new Ticket();
                Console.WriteLine(t.TicketNo);
            }
        }
    }
}