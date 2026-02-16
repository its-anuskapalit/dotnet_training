using System;
using System.Collections.Generic;
using System.Linq;

public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }

    public int CompareTo(Team other)
    {
        int pointComparison = other.Points.CompareTo(this.Points);
        if (pointComparison != 0)
            return pointComparison;

        return this.Name.CompareTo(other.Name);
    }
}
public class Match
{
    public Team Team1 { get; }
    public Team Team2 { get; }

    public Match(Team t1, Team t2)
    {
        Team1 = t1;
        Team2 = t2;
    }
    public Match Clone()
    {
        return new Match(Team1, Team2);
    }
}
public class Tournament
{
    private List<Team> _teams = new List<Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();

    public void AddTeam(Team team)
    {
        _teams.Add(team);
    }
    public void ScheduleMatch(Match match)
    {
        _schedule.AddLast(match);
    }
    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        _undoStack.Push(match.Clone());
        if (team1Score > team2Score)
            match.Team1.Points += 3;
        else if (team2Score > team1Score)
            match.Team2.Points += 3;
        else
        {
            match.Team1.Points += 1;
            match.Team2.Points += 1;
        }
    }
    public void UndoLastMatch()
    {
        if (_undoStack.Count == 0) return;

        var match = _undoStack.Pop();
        match.Team1.Points = 0;
        match.Team2.Points = 0;
    }
    public List<Team> GetRankings()
    {
        return _teams.OrderByDescending(t => t.Points)
                     .ThenBy(t => t.Name)
                     .ToList();
    }
    public int GetTeamRanking(Team team)
    {
        var rankings = GetRankings();
        return rankings.IndexOf(team) + 1;
    }
}
class Program
{
    static void Main()
    {
        Tournament tournament = new Tournament();
        Team A = new Team { Name = "Team A", Points = 0 };
        Team B = new Team { Name = "Team B", Points = 0 };

        tournament.AddTeam(A);
        tournament.AddTeam(B);
        Match match = new Match(A, B);
        tournament.ScheduleMatch(match);
        tournament.RecordMatchResult(match, 3, 1);

        var rankings = tournament.GetRankings();
        Console.WriteLine("Top Ranked Team: " + rankings[0].Name);
        tournament.UndoLastMatch();
        Console.WriteLine("Team B Points After Undo: " + A.Points);
    }
}
