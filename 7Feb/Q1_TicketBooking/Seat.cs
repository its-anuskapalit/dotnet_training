using System;

public class Seat
{
    public int SeatNo { get; }
    public bool IsBooked { get; private set; }

    public Seat(int seatNo)
    {
        SeatNo = seatNo;
    }

    public void Book()
    {
        if (IsBooked)
            throw new InvalidOperationException();

        IsBooked = true;
    }
}
