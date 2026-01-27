using ConferenceAgendaPlanner.Models;
using ConferenceAgendaPlanner.Utils;

namespace ConferenceAgendaPlanner.Scheduling;

/// <summary>
/// Builds a personal agenda (sequence of sessions) for an attendee
/// based on their preferences, session capacities, and venue walking constraints.
/// </summary>
public class AgendaBuilder
{
    // Mapping of session id to Session object.
    private readonly Dictionary<string, Session> _sessions;

    // Mapping of venue id to Venue object.
    private readonly Dictionary<string, Venue> _venues;

    // Maximum walking distance/time allowed between sessions.
    private readonly int _maxWalk;

    // Initialize the builder with available sessions, venues and walking constraint.
    public AgendaBuilder(
        Dictionary<string, Session> sessions,
        Dictionary<string, Venue> venues,
        int maxWalk)
    {
        _sessions = sessions;
        _venues = venues;
        _maxWalk = maxWalk;
    }

    // Build an agenda for a single attendee from their preferences.
    public List<Session> BuildAgenda(
        List<Preference> prefs)
    {
        // Order preferences by score (desc), map to sessions, then order by session start time.
        var ordered = prefs
            .OrderByDescending(p => p.Score)
            .Select(p => _sessions[p.SessionId])
            .OrderBy(s => s.Start)
            .ToList();

        var agenda = new List<Session>();
        foreach (var session in ordered)
        {
            // Skip if session is already full.
            if (session.Used >= session.Capacity)
                continue;

            // If agenda is empty, take the session.
            if (agenda.Count == 0)
            {
                agenda.Add(session);
                session.Used++;
                continue;
            }

            var last = agenda.Last();

            // Add session only if it does not overlap with the last chosen session
            // and it's feasible to travel between venues within max walk constraints.
            if (!TimeUtils.Overlaps(
                    last.Start, last.End,
                    session.Start, session.End)
                && FeasibilityChecker.CanAttend(
                    last, session, _venues, _maxWalk))
            {
                agenda.Add(session);
                session.Used++;
            }
        }

        // Return the constructed agenda.
        return agenda;
    }
}
