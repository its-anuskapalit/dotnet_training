/// <summary>
/// Models used by the Conference Agenda Planner application.
/// This file defines the Preference model which represents a delegate's preference for a specific session.
/// </summary>
namespace ConferenceAgendaPlanner.Models;
public class Preference
{
    public string DelegateId;
    public string SessionId;
    public int Score;
}
