using System;

namespace ExamManagement
{
    /// <summary>
    /// <para>Represents a student in the exam management system.</para>
    /// </summary>
    class Student
    {
        public int StudentId;
        public string Name;
        public Semester Semester;
        public List<Result> Results = new List<Result>();
    }

}
