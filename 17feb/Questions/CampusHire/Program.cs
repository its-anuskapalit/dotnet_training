using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Applicant
{
    public string ApplicantId { get; set; }
    public string ApplicantName { get; set; }
    public string CurrentLocation { get; set; }
    public string PreferredLocation { get; set; }
    public string CoreCompetency { get; set; }
    public int PassingYear { get; set; }
}

class Program
{
    static List<Applicant> applicants = new List<Applicant>();
    static string filePath = "applicants.json";

    static void Main()
    {
        LoadData();

        while (true)
        {
            Console.WriteLine("\n--- CampusHire Applicant Management ---");
            Console.WriteLine("1. Add Applicant");
            Console.WriteLine("2. Display All Applicants");
            Console.WriteLine("3. Search Applicant by ID");
            Console.WriteLine("4. Update Applicant");
            Console.WriteLine("5. Delete Applicant");
            Console.WriteLine("6. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddApplicant(); break;
                case "2": DisplayAll(); break;
                case "3": SearchApplicant(); break;
                case "4": UpdateApplicant(); break;
                case "5": DeleteApplicant(); break;
                case "6": SaveData(); return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }

    static void AddApplicant()
    {
        Applicant a = new Applicant();

        Console.WriteLine("Enter Applicant ID (CH123456): ");
        string id = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(id) || id.Length != 8 || !id.StartsWith("CH"))
        {
            Console.WriteLine("Invalid Applicant ID");
            return;
        }
        if (applicants.Exists(x => x.ApplicantId == id))
        {
            Console.WriteLine("Applicant ID already exists");
            return;
        }
        Console.WriteLine("Enter Applicant Name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || name.Length > 15)
        {
            Console.WriteLine("Invalid Name");
            return;
        }
        Console.WriteLine("Enter Current Location (Mumbai/Pune/Chennai): ");
        string currentLoc = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(currentLoc))
        {
            Console.WriteLine("Invalid Current Location");
            return;
        }
        Console.WriteLine("Enter Preferred Location (Mumbai/Pune/Chennai/Delhi/Kolkata/Bangalore): ");
        string prefLoc = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(prefLoc))
        {
            Console.WriteLine("Invalid Preferred Location");
            return;
        }
        Console.Write("Enter Core Competency (.NET/JAVA/ORACLE/Testing): ");
        string competency = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(competency))
        {
            Console.WriteLine("Invalid Competency");
            return;
        }
        Console.Write("Enter Passing Year: ");
        if (!int.TryParse(Console.ReadLine(), out int year) || year > DateTime.Now.Year)
        {
            Console.WriteLine("Invalid Passing Year");
            return;
        }
        a.ApplicantId = id;
        a.ApplicantName = name;
        a.CurrentLocation = currentLoc;
        a.PreferredLocation = prefLoc;
        a.CoreCompetency = competency;
        a.PassingYear = year;

        applicants.Add(a);
        SaveData();
        Console.WriteLine("Applicant Added Successfully");
    }

    static void DisplayAll()
    {
        if (applicants.Count == 0)
        {
            Console.WriteLine("No records found");
            return;
        }

        foreach (var a in applicants)
        {
            Console.WriteLine("\n-------------------------");
            Console.WriteLine($"ID: {a.ApplicantId}");
            Console.WriteLine($"Name: {a.ApplicantName}");
            Console.WriteLine($"Current Location: {a.CurrentLocation}");
            Console.WriteLine($"Preferred Location: {a.PreferredLocation}");
            Console.WriteLine($"Competency: {a.CoreCompetency}");
            Console.WriteLine($"Passing Year: {a.PassingYear}");
        }
    }

    static void SearchApplicant()
    {
        Console.Write("Enter Applicant ID: ");
        string id = Console.ReadLine();

        var applicant = applicants.Find(x => x.ApplicantId == id);
        if (applicant == null)
        {
            Console.WriteLine("Applicant not found");
            return;
        }
        Console.WriteLine($"Name: {applicant.ApplicantName}");
        Console.WriteLine($"Current Location: {applicant.CurrentLocation}");
        Console.WriteLine($"Preferred Location: {applicant.PreferredLocation}");
        Console.WriteLine($"Competency: {applicant.CoreCompetency}");
        Console.WriteLine($"Passing Year: {applicant.PassingYear}");
    }

    static void UpdateApplicant()
    {
        Console.Write("Enter Applicant ID to update: ");
        string id = Console.ReadLine();

        var applicant = applicants.Find(x => x.ApplicantId == id);

        if (applicant == null)
        {
            Console.WriteLine("Applicant not found");
            return;
        }

        Console.WriteLine("Enter New Name: ");
        applicant.ApplicantName = Console.ReadLine();

        Console.WriteLine("Enter New Preferred Location: ");
        applicant.PreferredLocation = Console.ReadLine();

        Console.WriteLine("Enter New Core Competency: ");
        applicant.CoreCompetency = Console.ReadLine();

        Console.WriteLine("Enter New Passing Year: ");
        applicant.PassingYear = int.Parse(Console.ReadLine());

        SaveData();

        Console.WriteLine("Applicant Updated Successfully");
    }

    static void DeleteApplicant()
    {
        Console.Write("Enter Applicant ID to delete: ");
        string id = Console.ReadLine();
        var applicant = applicants.Find(x => x.ApplicantId == id);
        if (applicant == null)
        {
            Console.WriteLine("Applicant not found");
            return;
        }
        applicants.Remove(applicant);
        SaveData();
        Console.WriteLine("Applicant Deleted Successfully");
    }
    static void SaveData()
    {
        string json = JsonSerializer.Serialize(applicants);
        File.WriteAllText(filePath, json);
    }
    static void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            applicants = JsonSerializer.Deserialize<List<Applicant>>(json) ?? new List<Applicant>();
        }
    }
}
