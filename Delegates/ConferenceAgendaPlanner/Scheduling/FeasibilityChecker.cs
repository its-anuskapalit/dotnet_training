// Summary: Helpers to determine whether an attendee can feasibly move between two sessions
// given session times and walking distance between venues.

using ConferenceAgendaPlanner.Models;
using ConferenceAgendaPlanner.Utils;

namespace ConferenceAgendaPlanner.Scheduling;

/// <summary>
/// Provides methods to check whether it is feasible for an attendee to move from one
/// session to another based on start/end times and walking distance between venues.
/// </summary>
public static class FeasibilityChecker
{
    /// <summary>
    /// Determines if an attendee can attend 'next' after finishing 'prev'.
    /// </summary>
    /// <param name="prev">The session that ends first.</param>
    /// <param name="next">The session that starts after the previous one.</param>
    /// <param name="venues">Lookup of venue information by venue id.</param>
    /// <param name="maxWalk">Maximum allowable walking distance between venues.</param>
    /// <returns>True if the attendee can make it in time and within the walking limit.</returns>
    public static bool CanAttend(
        Session prev,
        Session next,
        Dictionary<string, Venue> venues,
        int maxWalk)
    {
        // If the previous session ends after the next one starts, they overlap -> cannot attend.
        if (prev.End > next.Start)
            return false;

        // Retrieve venue locations for both sessions.
        var v1 = venues[prev.VenueId];
        var v2 = venues[next.VenueId];

        // Calculate distance between venues and compare to allowed maximum walking distance.
        return DistanceCalculator.Distance(v1, v2) <= maxWalk;
    }
}
