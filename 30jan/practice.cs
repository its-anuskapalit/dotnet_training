using System;
using System.Collections.Generic;

namespace PracticeDelegates
{
    public delegate void Notify(string message);

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Marks { get; set; }

        public event Notify? OnNotify;

        public int CompareTo(Student? other)
        {
            if (other == null) return 1;
            return other.Marks.CompareTo(this.Marks);
        }

        public void SendNotification()
        {
            Predicate<int> isPoor = m => m < 500;
            Predicate<int> isGood = m => m >= 560;

            Func<int, string> getCategory = m =>
            {
                if (isPoor(m)) return "Needs Improvement";
                if (isGood(m)) return "Good Student";
                return "Average Student";
            };

            Action<string> notify = msg =>
            {
                OnNotify?.Invoke(msg);
            };
            string result = getCategory(Marks);
            notify(result);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { Name = "Anuska", Marks = 500 },
                new Student { Name = "Sachin", Marks = 450 },
                new Student { Name = "Devi", Marks = 550 },
                new Student { Name = "Ayushi", Marks = 600 },
                new Student { Name = "Sukurtha", Marks = 560 }
            };

            foreach (var s in students)
            {
                s.OnNotify += ShowRemark;
            }
            students.Sort();

            int rank = 1;
            foreach (var s in students)
            {
                Console.Write($"Rank {rank++}: {s.Name}, Marks = {s.Marks}, Remark = ");
                s.SendNotification();
                Console.WriteLine();
            }
        }

        static void ShowRemark(string message)
        {
            Console.Write(message);
        }
    }
}
