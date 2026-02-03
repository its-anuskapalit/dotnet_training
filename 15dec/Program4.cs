using System;
using System.Collections;
namespace Q4{
    public class Member
    {
    public int ID;
    public int Age;
    public double Weight;
    public double Height;
    public string? Goal;
    public double BMI;
    }
public class Program
{
    public static ArrayList memberList=new ArrayList();
     public static void AddYogaMember(int id, int age, double weight, double height, string? goal)
        {
            Member m = new Member();
            m.ID = id;
            m.Age = age;
            m.Weight = weight;
            m.Height = height;
            m.Goal = goal;
            memberList.Add(m);
        }
        public static double CalculateBMI(int memberid)
        {
            foreach(Member i in memberList)
            {
                if (i.ID == memberid)
                {
                    i.BMI = i.Weight / (i.Height * i.Height);
                    return i.BMI;
                }
            }
            return 0;
        }
        public int CalculateYogaFee(int memberid)
        {
            int fee=0;
            foreach(Member i in memberList)
            {
                if(i.Goal=="Weight Loss"){
                if(i.BMI >=25 && i.BMI < 30)
                {
                    fee=2000;
                }
                else if(i.BMI >=30 && i.BMI < 35)
                {
                    fee=2500;
                }
                else if(i.BMI > 35)
                {
                    fee=3000;
                }
                }
                else if(i.Goal=="Weight Gain")
                {
                    fee=2500;
                }
            }
            return fee;
        }

public static void Main()
{
    Program p = new Program();

    Console.WriteLine("Enter Member ID:");
    int id = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter Age:");
    int age = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter Weight:");
    double weight = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter Height:");
    double height = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter Goal (Weight Loss / Weight Gain):");
    string goal = Console.ReadLine();

    AddYogaMember(id, age, weight, height, goal);

    double bmi = CalculateBMI(id);
    Console.WriteLine("\nBMI = " + Math.Round(bmi,2));

    int fee = p.CalculateYogaFee(id);
    Console.WriteLine("Yoga Fee = Rs." + fee);
}



}
}