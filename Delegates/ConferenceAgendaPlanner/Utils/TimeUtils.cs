namespace ConferenceAgendaPlanner.Utils;
/// <summary>
/// Provides helper methods for time interval operations.
/// </summary>
public static class TimeUtils
{
    public static bool Overlaps(int s1, int e1, int s2, int e2)
    {
        // Intervals do not overlap if one ends before or at the other's start.
        return !(e1 <= s2 || e2 <= s1);
    }
}
