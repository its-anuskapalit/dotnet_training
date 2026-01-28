using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Represents a scheduled session within the conference agenda, including its identity,
/// scheduled start and end times, venue assignment, and capacity usage.
/// </summary>
namespace ConferenceAgendaPlanner.Models
{
    public class Session
    {
        public string Id;
        public int Start;
        public int End;
        public string VenueId;
        public int Capacity;
        public int Used = 0;
    }
}
