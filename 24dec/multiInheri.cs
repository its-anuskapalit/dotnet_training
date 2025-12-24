using System;
namespace multi
{
    //multiple inheritance using interface
    //interface 1
    public interface VegEater
    {
        public void display();
    }
    //interface 2
    public interface NonVegEater
    {
        public void display();
    }
    //implementing multiple inheritance
    public class Visitor: VegEater, NonVegEater
    {
        //implementing interface methods
        void VegEater.display()
        {
            Console.WriteLine("Veg");
        }
        void NonVegEater.display()
        {
            Console.WriteLine("NOnVeg");
        }
    }
    }