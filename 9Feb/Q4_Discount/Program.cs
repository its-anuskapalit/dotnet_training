using System;

namespace Q4
{
    abstract class DiscountPolicy
    {
        public abstract double GetFinalAmt(double amt);
    }

    class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmt(double amt)
        {
            if (amt >= 5000)
                return amt - (amt * 0.10);
            else
                return amt - (amt * 0.05);
        }
    }

    class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmt(double amt)
        {
            if (amt >= 2000)
                return amt - 300;
            return amt;
        }
    }
    class Program
    {
        static void Main()
        {
            DiscountPolicy discount;

            Console.WriteLine("Enter amount:");
            double amt = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter discount type (Festival/Member):");
            string type = Console.ReadLine();

            if (type == "Festival")
                discount = new FestivalDiscount();
            else
                discount = new MemberDiscount();

            Console.WriteLine("Final Amount: " + discount.GetFinalAmt(amt));
        }
    }
}
