using ConferenceAgendaPlanner.Models;
using System;

namespace ConferenceAgendaPlanner.Utils
{
    /// <summary>
    /// Utility methods for calculating geometric distances between Venue instances.
    /// Used by the agenda planner to estimate travel distances between venues.
    /// </summary>
    public static class DistanceCalculator
    {
        public static int Distance(Venue a, Venue b)
        {
            // difference in X coordinates
            int dx = a.X - b.X;
            // difference in Y coordinates
            int dy = a.Y - b.Y;
            // compute Euclidean distance and cast to int
            return (int)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
