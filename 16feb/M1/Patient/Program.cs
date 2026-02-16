using System;
using System.Collections.Generic;
using System.Linq;

public class Patient
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Condition { get; private set; }
    public List<string> MedicalHistory { get; private set; }

    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }

    public void AddMedicalRecord(string record)
    {
        MedicalHistory.Add(record);
    }
}

public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (!_patients.ContainsKey(id))
        {
            var patient = new Patient(id, name, age, condition);
            _patients.Add(id, patient);
        }
    }

    public void ScheduleAppointment(int patientId)
    {
        if (_patients.ContainsKey(patientId))
            _appointmentQueue.Enqueue(_patients[patientId]);
    }

    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count > 0)
            return _appointmentQueue.Dequeue();
        return null;
    }

    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values
                        .Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase))
                        .ToList();
    }
}
class Program
{
    static void Main()
    {
        HospitalManager manager = new HospitalManager();

        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.RegisterPatient(3, "Mike Ross", 50, "Diabetes");

        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var patient = manager.ProcessNextAppointment();
        Console.WriteLine($"Processing: {patient.Name}");

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");

        Console.WriteLine("Diabetic Patients:");
        foreach (var p in diabeticPatients)
            Console.WriteLine(p.Name);
    }
}
