using ConferenceAgendaPlanner.Models;

namespace ConferenceAgendaPlanner.Output;

public class Result
{
    public Dictionary<string, List<string>> Assignments = new();
    public int TotalScore;
    public int TotalWalk;
}
