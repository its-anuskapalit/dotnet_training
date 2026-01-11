//Abtract class
// Cannot Be Instantiated
// Can Contain Both Abstract and Concrete Methods
// Abstract Methods Have No Body
// Can Have Constructors
// Cannot Be Declared as final or sealed
//
public abstract class Loan
{
    public abstract decimal CalculateEMI();
    public void Validate()
    {
        Console.WriteLine("Loan Validated");
    }
}
public class HomeLoan : Loan
{
    public override decimal CalculateEMI()
    {
        return 45000;
    }
}