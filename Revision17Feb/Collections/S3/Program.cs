using System;
using System.Collections.Generic;

class TicketSystem
{
    private Queue<string> tickets = new Queue<string>();

    public void RaiseTicket(string ticket)
    {
        tickets.Enqueue(ticket);
        Console.WriteLine($"Ticket Raised: {ticket}");
    }

    public void ResolveTicket()
    {
        if (tickets.Count > 0)
        {
            var resolved = tickets.Dequeue();
            Console.WriteLine($"Resolved: {resolved}");
        }
        else
        {
            Console.WriteLine("No tickets pending.");
        }
    }
}

class Program
{
    static void Main()
    {
        TicketSystem system = new TicketSystem();

        system.RaiseTicket("Login Issue");
        system.RaiseTicket("Payment Failed");

        system.ResolveTicket();
        system.ResolveTicket();
    }
}
