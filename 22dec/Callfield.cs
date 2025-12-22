using System;
// CALLING FIELD FROM BASE CLASS PROGRAM
namespace Oops
{
    public class Callfield
    {
        public static void Main()
        {
            // Employee emp=new Employee();
            // emp.Id=100;
            // string result=emp.DisplayEmpDetails();
            // Console.WriteLine(result);

            Associate ab=new Associate();
            ab.Id=0;
            ab.Name="";
            ab.Rank=0;
            // Adding error messages to the list
            foreach (string error in ab.list){
                Console.WriteLine(error);
                }
            string result=ab.DisplayEmpDetails();
            Console.WriteLine(result);
        }
    }
}