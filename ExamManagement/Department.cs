using System;

namespace ExamManagement
{
    /// <summary>
    /// <para>Represents a department within an educational institution.</para>
    /// </summary>
    class Department
    {
        public string Name;
        public List<Student> Students = new List<Student>();
        public List<Person> People = new List<Person>();
        public List<Semester> Semesters = new List<Semester>();
    }

}
