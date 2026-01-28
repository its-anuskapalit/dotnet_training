using CheckInSimulation.Models;
using CheckInSimulation.Optimizer;

class Program
{
    static void Main()
    {
        int G = 2;
        long W = 60000;

        var arrivals = new List<DelegateArrival>
        {
            new() { ArrivalTime=0, LookupTime=1000, BagTime=2000 },
            new() { ArrivalTime=0, LookupTime=2000, BagTime=3000 },
            new() { ArrivalTime=1000, LookupTime=1000, BagTime=2000 },
            new() { ArrivalTime=2000, LookupTime=1000, BagTime=80000 },
            new() { ArrivalTime=3000, LookupTime=1000, BagTime=2000 }
        };

        int minScanners = StaffingOptimizer.FindMinimumScanners(arrivals, G, W);
        Console.WriteLine($"Minimum scanners needed: {minScanners}");
    }
}
