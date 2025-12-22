using System;
//clss to Calculate roots of $ax^2 + bx + c = 0$ using if-else to check the discriminant.
class discriminate
{
    public static void cal()
    {
        double a, b, c;
        Console.WriteLine("Enter coefficients a, b, and c:");
        // Basic input parsing 
        a = Convert.ToDouble(Console.ReadLine());
        b = Convert.ToDouble(Console.ReadLine());
        c = Convert.ToDouble(Console.ReadLine());
        // calculated discriminate 
        double discriminant = b * b - 4 * a * c;
        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine($"Two distinct real roots: Root 1 = {root1}, Root 2 = {root2}");
        }
        // single root case
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            Console.WriteLine($"One real root: Root = {root}");
        }
        // complex roots case
        else
        {
            double realPart = -b / (2 * a);
            double imaginaryPart = Math.Sqrt(-discriminant) / (2 * a);
            Console.WriteLine($"Complex roots: Root 1 = {realPart} + {imaginaryPart}i, Root 2 = {realPart} - {imaginaryPart}i");
        }
    }
}
