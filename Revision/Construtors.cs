//Constructors
public class Account
{
    public int id;
    public decimal Balance;
    public decimal InterestRate;
     Account()
    {
        InterestRate= 4.5m;
    }
    public Account(int id,decimal bal)
    {
        id=id;
        Balance=bal;
    }
}