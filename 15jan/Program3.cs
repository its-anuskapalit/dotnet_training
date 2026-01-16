using System;
using System.Collections.Generic;
namespace Q3
{
    class Program
    {
        public static List<int> NumberList = new List<int>();

        public void AddNumber(int number)
        {
            NumberList.Add(number);
        }
        public static double GetGPAScore()
        {
            int sum = 0;
            foreach (var i in NumberList)
                sum += (i*3);

            return (double)(sum / (NumberList.Count*3))/10;
        }
        public static char GetGradeScore(double gpa)
        {
            if (gpa == 10)
                return 'S';
            else if (gpa >= 9)
                return 'A';
            else if (gpa >= 8)
                return 'B';
            else if (gpa >= 7)
                return 'C';
            else if (gpa >= 6)
                return 'D';
            else if (gpa >= 5)
                return 'E';
            else
                return ' ';
            
        }

        public static void Main()
        {
            Program p = new Program();

            Console.WriteLine("Enter 5 subject marks:");
            for (int i = 0; i < 5; i++)
            {
                int mark = int.Parse(Console.ReadLine());
                p.AddNumber(mark);
            }

            double gpa = GetGPAScore();
            Console.WriteLine("\nGPA Score: " + gpa);
            char grade = GetGradeScore(gpa);
            if(grade ==' ')
            {
                Console.WriteLine("Invalid GPA");
            }
            else
            {
             Console.WriteLine("\nGPA Score: " + gpa);   
            }
            Console.WriteLine("Grade: " + grade);
        }
    }
}
