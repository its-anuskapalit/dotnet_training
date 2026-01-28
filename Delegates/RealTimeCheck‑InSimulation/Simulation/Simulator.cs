using CheckInSimulation.Models;
using CheckInSimulation.Metrics;
using System.Collections.Generic;
using System.Linq;

namespace CheckInSimulation.Simulation;

public class Simulator
{
    private readonly List<Gate> _gates;
    private readonly StatisticsTracker _stats;

    public Simulator(List<Gate> gates, StatisticsTracker stats)
    {
        _gates = gates;
        _stats = stats;
    }

    public void Run(List<DelegateArrival> arrivals)
    {
        foreach (var arrival in arrivals)
        {
            Gate chosenGate = ChooseGate();
            chosenGate.Queue.Enqueue(arrival);

            chosenGate.MaxQueueLength = Math.Max(
                chosenGate.MaxQueueLength,
                chosenGate.Queue.Count
            );

            TryServe(chosenGate, arrival.ArrivalTime);
        }
    }

    private Gate ChooseGate()
    {
        return _gates
            .OrderBy(g => g.Queue.Count)
            .ThenBy(g => g.GateId)
            .First();
    }

    private void TryServe(Gate gate, long currentTime)
    {
        foreach (var scanner in gate.Scanners)
        {
            if (scanner.FreeAtTime <= currentTime && gate.Queue.Count > 0)
            {
                var person = gate.Queue.Dequeue();
                long waitTime = currentTime - person.ArrivalTime;

                _stats.Record(waitTime);

                scanner.FreeAtTime = currentTime + person.ServiceTime;
            }
        }
    }
}
