using System;
using System.Collections.Generic;

public class TicketBookingService
{
    private readonly Dictionary<int, Seat> _seats;
    private readonly object _lock = new();

    public TicketBookingService(IEnumerable<int> seatNumbers)
    {
        _seats = new Dictionary<int, Seat>();
        foreach (var seat in seatNumbers)
            _seats[seat] = new Seat(seat);
    }

    public bool BookSeat(int seatNo, string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException();

        lock (_lock)
        {
            if (!_seats.ContainsKey(seatNo))
                throw new ArgumentException();

            if (_seats[seatNo].IsBooked)
                return false;

            _seats[seatNo].Book();
            return true;
        }
    }
}
