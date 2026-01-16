using System;
namespace Q7{
public class EstimateDetails
{
    public float? CArea;
    public float? SArea;
}
public class EstimateException : Exception
    {
        public EstimateException(string message) : base(message) { }
    }
public class Program{
    public static EstimateDetails ValidateArea(float a, float b)
        {
            EstimateDetails u=new EstimateDetails();
            u.CArea=a;
            u.SArea=b;
            if(a>b )
            {
                throw new EstimateException("Sry your Construction Estimate not approved");
            }
            return u;
        }
        public static void Main()
        {
             try
            {
                Console.WriteLine("Enter Construction Area:");
                float a = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter site Area:");
                float b = float.Parse(Console.ReadLine());

                EstimateDetails u  = ValidateArea(a,b);
        
            }
            catch (EstimateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
                }
}