using System;
namespace Oops
{
    /// <summary>
    /// <para>Abstract class representing an Employee with a method for tax calculation.</para>
    /// </summary>
    public abstract class Employee
    {
        public int amt;

        public abstract int TaxCalculation(int amt);
    }
    //multiple inheritance
    ///derived class
    public class USEmployee : Employee
    {
        public override int TaxCalculation(int amt)
        {
            return amt * 19 / 100;
        }
    }
    ///derived class
    public class IndiaEmployee : Employee
    {
        public override int TaxCalculation(int amt)
        {
            return amt * 23 / 100;
        }
    }
}
