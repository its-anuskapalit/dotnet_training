using System;
using System.Collections.Generic;
using System.Text;

namespace ExamManagement
{
    /// <summary>
    /// <para>Represents an examiner who evaluates student results.</para>
    /// </summary>
    class Examiner : Person
    {
        public void Evaluate(Result r, int marks)
        {
            r.Marks = marks;
            if (marks >= 80) r.Grade = "A";
            else if (marks >= 60) r.Grade = "B";
            else r.Grade = "C";
        }
    }

}
