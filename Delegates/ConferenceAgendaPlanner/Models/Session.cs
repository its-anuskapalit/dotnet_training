using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Represents a scheduled session within the conference agenda, including its identity,
/// scheduled start and end times, venue assignment, and capacity usage.
/// </summary>
/// <remarks>
/// Times are represented as integers (for example: minutes from midnight or a discrete timeslot index).
/// Ensure a consistent interpretation across the application.
/// </remarks>

/// <summary>Unique identifier for the session.</summary>

/// <summary>Start time of the session (integer representation; interpretation per application).</summary>

/// <summary>End time of the session (integer representation; interpretation per application).</summary>

/// <summary>Identifier of the venue where the session takes place.</summary>

/// <summary>Maximum number of attendees allowed for this session.</summary>

/// <summary>Number of occupied seats for this session. Defaults to 0.</summary>
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
