using System;

namespace MyProject;

public class Employee
{
    private int employeeId;
    private string name;
    private string designation;

    public Employee(int id, string name, string designation)
    {
        employeeId = id;
        this.name = name;
        this.designation = designation;
    }

    public string GetName()
    {
        return name;
    }

    public static bool Participate(int competitionId)
    {
        Console.WriteLine($"Participate in competition {competitionId}? (true/false): ");
        return bool.TryParse(Console.ReadLine(), out bool result) && result;
    }
}

public class Competition
{
    private int competitionId;
    private string competitionName;

    public Competition(int id, string name)
    {
        competitionId = id;
        competitionName = name;
    }

    public int GetId()
    {
        return competitionId;
    }

    public static int GetWinnerIndex(int[] scores)
    {
        int max = scores[0];
        int winnerIndex = 0;

        for (int i = 1; i < scores.Length; i++)
        {
            if (scores[i] > max)
            {
                max = scores[i];
                winnerIndex = i;
            }
        }
        return winnerIndex;
    }
}

public class Details
{
    private Employee[] employees;
    private Competition competition;
    private int[] scores;

    public Details(Employee[] employees, Competition competition)
    {
        this.employees = employees;
        this.competition = competition;
        scores = new int[employees.Length];
    }

    public void CollectScores()
    {
        for (int i = 0; i < employees.Length; i++)
        {
            if (Employee.Participate(competition.GetId()))
            {
                Console.Write($"Enter score for {employees[i].GetName()}: ");
                int.TryParse(Console.ReadLine(), out scores[i]);
            }
        }
    }

    public void DisplayWinner()
    {
        int winnerIndex = Competition.GetWinnerIndex(scores);
        Console.WriteLine($"Winner is: {employees[winnerIndex].GetName()}");
    }
}

