using System;
using MathsLib;
using ScienceLib;
namespace MultiCalculationApp
{
    public class Program
    {
       static void Main()
        {
            // Create instances of the classes from different namespaces
            MathsProgram ob =new MathsProgram();
            double result1=ob.Add(10,20);
            double result2=ob.Subtract(20,10);

            // Create instance of AcroScience class
            AcroScience ob1 =new AcroScience();
            double result3=ob1.CalculateForce(10,9.8);

            // Create instance of SciLogin class
            SciLogin sci =new SciLogin();
            Console.WriteLine(sci.Login("user", "password"));
            sci.Logout();

            //printing results
            Console.WriteLine("Addition Result: " + result1);
            Console.WriteLine("Subtraction Result: " + result2);
            Console.WriteLine("Force Calculation Result: " + result3);

            // Call the private helper method via a public method if needed
            ob.HelperMethod();
            int result4= ob.Multiple(2,3);

        }
    }
}
