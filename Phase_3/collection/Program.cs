using System;
using System.Collections;
using System.Collections.Generic;

namespace JobEngine
{
    class Job
    {
        public int Id;
        public string Name;
    }

    class JobProcessor
    {
        private readonly Queue<Job> pendingJobs = new();
        private readonly Stack<Job> completedJobs = new();
        private readonly Dictionary<int, Job> jobIndex = new();
        private readonly List<Job> allJobs = new();

        public void AddJob(Job job)
        {
            pendingJobs.Enqueue(job);
            jobIndex[job.Id] = job;
            allJobs.Add(job);
        }

        public void ProcessNext()
        {
            if (pendingJobs.Count == 0)
                return;

            Job job = pendingJobs.Dequeue();
            Console.WriteLine($"Processing {job.Name}");
            completedJobs.Push(job);
        }

        public void UndoLast()
        {
            if (completedJobs.Count == 0)
                return;

            Job job = completedJobs.Pop();
            Console.WriteLine($"Undo {job.Name}");
            pendingJobs.Enqueue(job);
        }

        public Job FindById(int id)
        {
            return jobIndex.TryGetValue(id, out Job job) ? job : null;
        }
    }

    class Program
    {
        static void Main()
        {
            JobProcessor processor = new();

            processor.AddJob(new Job { Id = 1, Name = "Import Data" });
            processor.AddJob(new Job { Id = 2, Name = "Generate Report" });

            processor.ProcessNext();
            processor.ProcessNext();
            processor.UndoLast();

            Job found = processor.FindById(1);
            Console.WriteLine(found.Name);
        }
    }
}
