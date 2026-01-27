/*
 Summary:
 This file is the entry point for the ConferenceAgendaPlanner sample app.
 It sets up sample venues, sessions and delegate preferences, invokes the
 AgendaBuilder to create agendas for each delegate, and prints the resulting
 assignments and total score.
*/

using ConferenceAgendaPlanner.Models;
using ConferenceAgendaPlanner.Scheduling;
using ConferenceAgendaPlanner.Output;
using ConferenceAgendaPlanner.Utils;

class Program
{
    static void Main()
    {
        // T: travel/time threshold used by the agenda builder
        int T = 8;

        // Define available venues with simple coordinates
        var venues = new Dictionary<string, Venue>
        {
            { "A", new Venue { Id="A", X=0, Y=0 } },
            { "B", new Venue { Id="B", X=6, Y=0 } }
        };

        // Define sessions with start/end times, venue, and capacity
        var sessions = new Dictionary<string, Session>
        {
            { "S1", new Session { Id="S1", Start=540, End=600, VenueId="A", Capacity=1 } },
            { "S2", new Session { Id="S2", Start=600, End=660, VenueId="B", Capacity=1 } },
            { "S3", new Session { Id="S3", Start=540, End=630, VenueId="A", Capacity=1 } },
            { "S4", new Session { Id="S4", Start=660, End=720, VenueId="B", Capacity=1 } }
        };

        // Sample delegate preferences (scores indicate desirability)
        var preferences = new List<Preference>
        {
            new() { DelegateId="D1", SessionId="S1", Score=10 },
            new() { DelegateId="D1", SessionId="S2", Score=8 },
            new() { DelegateId="D1", SessionId="S4", Score=7 },
            new() { DelegateId="D2", SessionId="S3", Score=9 },
            new() { DelegateId="D2", SessionId="S2", Score=6 },
            new() { DelegateId="D2", SessionId="S4", Score=10 }
        };

        // Create the agenda builder with sessions, venues and threshold
        var builder = new AgendaBuilder(sessions, venues, T);
        var result = new Result();

        // Build an agenda for each delegate based on their preferences
        foreach (var group in preferences.GroupBy(p => p.DelegateId))
        {
            var agenda = builder.BuildAgenda(group.ToList());
            // Record assigned session IDs for the delegate
            result.Assignments[group.Key] = agenda.Select(s => s.Id).ToList();
            // Accumulate total score (sum of preference scores for this example)
            result.TotalScore += group.Sum(p => p.Score);
        }

        // Print assignments for each delegate
        foreach (var d in result.Assignments)
            Console.WriteLine($"{d.Key}: {string.Join(" ", d.Value)}");
    }
}
