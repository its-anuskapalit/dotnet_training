using System;
using System.Collections.Generic;
using System.Linq;

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public abstract class PatientBase : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }

    public override bool Equals(object obj)
    {
        return obj is PatientBase other && other.PatientId == PatientId;
    }

    public override int GetHashCode()
    {
        return PatientId.GetHashCode();
    }
}

public class PriorityQueue<T> where T : IPatient
{
    private readonly SortedDictionary<int, Queue<T>> _queues = new();

    public void Enqueue(T patient, int priority)
    {
        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        foreach (var priority in _queues.Keys.OrderBy(p => p))
        {
            if (_queues[priority].Count > 0)
                return _queues[priority].Dequeue();
        }

        throw new InvalidOperationException("Queue is empty");
    }

    public T Peek()
    {
        foreach (var priority in _queues.Keys.OrderBy(p => p))
        {
            if (_queues[priority].Count > 0)
                return _queues[priority].Peek();
        }

        throw new InvalidOperationException("Queue is empty");
    }

    public int GetCountByPriority(int priority)
    {
        return _queues.ContainsKey(priority) ? _queues[priority].Count : 0;
    }
}

public class MedicalRecord<T> where T : IPatient
{
    private readonly T _patient;
    private readonly List<(DateTime, string)> _diagnoses = new();
    private readonly Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }

    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        _diagnoses.Add((date, diagnosis));
    }

    public void AddTreatment(string treatment, DateTime date)
    {
        _treatments[date] = treatment;
    }

    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        return _treatments.OrderBy(t => t.Key);
    }
}

public class PediatricPatient : PatientBase
{
    public string GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : PatientBase
{
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}

public class MedicationSystem<T> where T : IPatient
{
    private readonly Dictionary<int, List<string>> _medications = new();

    public void PrescribeMedication(T patient, string medication, Func<T, bool> dosageValidator)
    {
        if (!dosageValidator(patient))
            throw new InvalidOperationException("Invalid dosage for patient");

        if (!_medications.ContainsKey(patient.PatientId))
            _medications[patient.PatientId] = new List<string>();

        _medications[patient.PatientId].Add(medication);
    }

    public bool CheckInteractions(T patient, string newMedication)
    {
        if (!_medications.ContainsKey(patient.PatientId))
            return false;

        return _medications[patient.PatientId].Contains(newMedication);
    }
}

public class Program
{
    public static void Main()
    {
        var pq = new PriorityQueue<IPatient>();

        var child1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Child1",
            DateOfBirth = DateTime.Now.AddYears(-5),
            BloodType = BloodType.A,
            Weight = 18
        };

        var old1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Old1",
            DateOfBirth = DateTime.Now.AddYears(-70),
            BloodType = BloodType.O,
            MobilityScore = 3
        };

        pq.Enqueue(child1, 2);
        pq.Enqueue(old1, 1);

        Console.WriteLine(pq.Dequeue().Name);
        Console.WriteLine(pq.Peek().Name);

        var recordChild = new MedicalRecord<PediatricPatient>(child1);
        recordChild.AddDiagnosis("Flu", DateTime.Today);
        recordChild.AddTreatment("Rest", DateTime.Today);

        var medsChild = new MedicationSystem<PediatricPatient>();
        medsChild.PrescribeMedication(child1, "Paracetamol", p => p.Weight > 10);

        Console.WriteLine(medsChild.CheckInteractions(child1, "Paracetamol"));
    }
}
