using CheckInSimulation.Models;
using CheckInSimulation.Metrics;
using CheckInSimulation.Simulation;

namespace CheckInSimulation.Optimizer;

public class StaffingOptimizer
{
    public static int FindMinimumScanners(
        List<DelegateArrival> arrivals,
        int gatesCount,
        long maxAllowedWait)
    {
        int scanners = gatesCount;

        while (true)
        {
            var gates = new List<Gate>();

            for (int i = 0; i < gatesCount; i++)
            {
                var gate = new Gate { GateId = i };
                gate.Scanners.Add(new Scanner());
                gates.Add(gate);
            }

            var stats = new StatisticsTracker();
            var sim = new Simulator(gates, stats);
            sim.Run(arrivals);

            if (stats.Percentile95() <= maxAllowedWait)
                return scanners;

            scanners++;
            gates[0].Scanners.Add(new Scanner());
        }
    }
}
