using System;
namespace ExamManagement
{
    /// <summary>
    /// class semester
    /// <para>Holds information about a semester including its number and the subjects offered in that semester.</para>
    /// </summary>

    class Semester
    {
        public int SemesterNo;
        public List<Subject> Subjects = new List<Subject>();
    }
}