/// <summary>
/// Represents arrival and service time components for a delegate in the check-in simulation.
/// Holds the arrival timestamp and durations for lookup and baggage handling.
/// </summary>
namespace CheckInSimulation.Models;

public class DelegateArrival
{
    public long ArrivalTime;
    public int LookupTime;
    public int BagTime;

    public long ServiceTime => LookupTime + BagTime;
}
