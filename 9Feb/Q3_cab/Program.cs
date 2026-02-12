using System;

namespace Q3
{
    public abstract class Cab
    {
        public virtual int CalculateFare(int km);
    }
    public class Mini : Cab
    {
        public override int CalculateFare(int km)
        {
            return km * 12;
        }
    }
    public class Sedan : Cab
    {
        public override int CalculateFare(int km)
        {
            return km * 15 + 50;
        }
    }
    public class SUV : Cab
    {
        public override int CalculateFare(int km)
        {
            return km * 18 + 100;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter cab type (Mini/Sedan/SUV):");
            string cabType = Console.ReadLine();

            Console.WriteLine("Enter distance in km:");
            int km = Convert.ToInt32(Console.ReadLine());

            Cab cab;

            if (cabType.Equals("Mini", StringComparison.OrdinalIgnoreCase))
                cab = new Mini();
            else if (cabType.Equals("Sedan", StringComparison.OrdinalIgnoreCase))
                cab = new Sedan();
            else if (cabType.Equals("SUV", StringComparison.OrdinalIgnoreCase))
                cab = new SUV();
            else
            {
                Console.WriteLine("Invalid cab type");
                return;
            }

            Console.WriteLine("Total Fare: " + cab.CalculateFare(km));
        }
    }
}
