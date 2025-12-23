using System;
using System.Reflection.Metadata.Ecma335;
namespace MainConstructor
{

    //crreating a parent class named father
    public abstract class Father
    {
        //declarations of members
        public int salary{get;set;}
        public double spendings {get;set;}

        // creating a class using virtual for Insurance
        public virtual string Insurance()
        {
            return $"The insurance amount is 3%";
        }
        //creating a class using abstract for adding amount to savings account
        public abstract int  SavingMoney();
        //creating a protected class for savings account details
        protected double Savings()
        {
            return 0.3*salary;
        }
        

    }

    //creating a child class inheriting the members salary and spending for the son class
    public class Son : Father
    {
        public override int SavingMoney()
        {
            throw new NotImplementedException();
        }

        public double Savings()
        {
            return 0.4*salary;
        }
    }


}