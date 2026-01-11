public class User
{
    public string Email;
    public void Login()
    {
        Console.WriteLine("User loggin in");
    }
}
class Admin: User
{
    public void ManagerUser()
    {
        Console.WriteLine("Managin user with "+ Email);
    }
}