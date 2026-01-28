/*
Summary: Represents a gate in the check-in simulation, holding a queue of arriving delegates,
a collection of scanners, and a tracked maximum queue length for statistics.
*/

using System.Collections.Generic;

namespace CheckInSimulation.Models;

public class Gate
{
    public int GateId;
    public Queue<DelegateArrival> Queue = new();
    public List<Scanner> Scanners = new();

    public int MaxQueueLength = 0;
}

