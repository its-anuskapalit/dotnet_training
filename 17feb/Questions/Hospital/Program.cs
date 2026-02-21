using System;
using System.Collections.Generic;
using System.Linq;

#region Custom Exceptions
public class DoctorNotAvailableException : Exception
{
    public DoctorNotAvailableException(string msg) : base(msg) { }
}

public class InvalidAppointmentException : Exception
{
    public InvalidAppointmentException(string msg) : base(msg) { }
}

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(string msg) : base(msg) { }
}

public class DuplicateMedicalRecordException : Exception
{
    public DuplicateMedicalRecordException(string msg) : base(msg) { }
}
#endregion

#region Interfaces
public interface IBillable
{
    decimal CalculateBill();
}
#endregion

#region Base Class
public abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    protected Person(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
#endregion

#region Entities
public class Doctor : Person, IBillable
{
    public string Specialization { get; set; }
    public decimal ConsultationFee { get; set; }
    public List<Appointment> Appointments { get; set; } = new();

    public Doctor(int id, string name, string specialization, decimal fee)
        : base(id, name)
    {
        Specialization = specialization;
        ConsultationFee = fee;
    }

    public decimal CalculateBill()
    {
        return Appointments.Count * ConsultationFee;
    }
}

public class Patient : Person
{
    public string Disease { get; set; }

    public Patient(int id, string name, string disease)
        : base(id, name)
    {
        Disease = disease;
    }
}

public class Appointment
{
    public int Id { get; set; }
    public Doctor Doctor { get; set; }
    public Patient Patient { get; set; }
    public DateTime Date { get; set; }
    public decimal Fee { get; set; }
}
#endregion

#region Medical Record (Encapsulation)
public class MedicalRecord
{
    public int PatientId { get; private set; }
    private string Diagnosis { get; set; }
    private string Treatment { get; set; }

    public MedicalRecord(int patientId, string diagnosis, string treatment)
    {
        PatientId = patientId;
        Diagnosis = diagnosis;
        Treatment = treatment;
    }

    public string GetRecord()
    {
        return $"Diagnosis: {Diagnosis}, Treatment: {Treatment}";
    }
}
#endregion

class Program
{
    static List<Doctor> doctors = new();
    static List<Patient> patients = new();
    static List<Appointment> appointments = new();
    static Dictionary<int, MedicalRecord> medicalRecords = new();

    static void Main()
    {
        SeedData();
        Menu();
    }

    static void SeedData()
    {
        doctors.Add(new Doctor(1, "Dr. Sharma", "Cardiology", 1000));
        doctors.Add(new Doctor(2, "Dr. Rao", "Orthopedic", 1500));

        patients.Add(new Patient(1, "Rohan", "Heart"));
        patients.Add(new Patient(2, "Amit", "Fracture"));
    }

    static void ScheduleAppointment()
    {
        Console.WriteLine("Enter Doctor Id:");
        int did = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Patient Id:");
        int pid = int.Parse(Console.ReadLine());

        var doctor = doctors.FirstOrDefault(d => d.Id == did);
        var patient = patients.FirstOrDefault(p => p.Id == pid);

        if (doctor == null)
            throw new DoctorNotAvailableException("Doctor not found");

        if (patient == null)
            throw new PatientNotFoundException("Patient not found");

        DateTime date = DateTime.Now.AddDays(1);

        if (doctor.Appointments.Any(a => a.Date == date))
            throw new InvalidAppointmentException("Overlapping appointment");

        Appointment appt = new Appointment
        {
            Id = appointments.Count + 1,
            Doctor = doctor,
            Patient = patient,
            Date = date,
            Fee = doctor.ConsultationFee
        };

        doctor.Appointments.Add(appt);
        appointments.Add(appt);

        Console.WriteLine("Appointment Scheduled");
    }

    static void AddMedicalRecord()
    {
        Console.WriteLine("Enter Patient Id:");
        int pid = int.Parse(Console.ReadLine());

        if (medicalRecords.ContainsKey(pid))
            throw new DuplicateMedicalRecordException("Record already exists");

        medicalRecords[pid] = new MedicalRecord(pid, "General Checkup", "Medicine A");

        Console.WriteLine("Medical Record Added");
    }

    static void Analytics()
    {
        Console.WriteLine("\nDoctors with >10 appointments:");
        var busyDocs = doctors.Where(d => d.Appointments.Count > 10);
        foreach (var d in busyDocs)
            Console.WriteLine(d.Name);

        Console.WriteLine("\nPatients treated last 30 days:");
        var recentPatients = appointments
            .Where(a => a.Date >= DateTime.Now.AddDays(-30))
            .Select(a => a.Patient.Name)
            .Distinct();

        foreach (var p in recentPatients)
            Console.WriteLine(p);

        Console.WriteLine("\nGroup Appointments by Doctor:");
        var grouped = appointments.GroupBy(a => a.Doctor.Name);
        foreach (var g in grouped)
            Console.WriteLine($"{g.Key} - {g.Count()}");

        Console.WriteLine("\nTop 3 Highest Earning Doctors:");
        var topDocs = doctors
            .OrderByDescending(d => d.CalculateBill())
            .Take(3);

        foreach (var d in topDocs)
            Console.WriteLine($"{d.Name} - {d.CalculateBill()}");

        Console.WriteLine("\nPatients by Disease (Projection):");
        var projection = patients
            .Select(p => new { p.Name, p.Disease });

        foreach (var p in projection)
            Console.WriteLine($"{p.Name} - {p.Disease}");

        Console.WriteLine("\nTotal Revenue:");
        Console.WriteLine(appointments.Sum(a => a.Fee));
    }

    static void ExportReport()
    {
        Console.WriteLine("\n--- Appointment Report ---");
        foreach (var a in appointments)
            Console.WriteLine($"Doctor: {a.Doctor.Name}, Patient: {a.Patient.Name}, Fee: {a.Fee}");
    }

    static void Menu()
    {
        while (true)
        {
            Console.WriteLine("\n1. Schedule Appointment");
            Console.WriteLine("2. Add Medical Record");
            Console.WriteLine("3. Analytics");
            Console.WriteLine("4. Export Report");
            Console.WriteLine("5. Exit");

            int choice = int.Parse(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        ScheduleAppointment();
                        break;
                    case 2:
                        AddMedicalRecord();
                        break;
                    case 3:
                        Analytics();
                        break;
                    case 4:
                        ExportReport();
                        break;
                    case 5:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
