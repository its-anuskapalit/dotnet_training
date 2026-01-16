using System;
namespace Q6{
public class User
{
    public string? Name;
    public string? Password;
    public string? conformationPassword;
}
public class Password : Exception
    {
        public Password(string message) : base(message) { }
    }
public class Program{
    public static User ValidatePassword(string name, string Password, string conformationPassword)
        {
            User u=new User();
            u.Name=name;
            u.Password=Password;
            u.conformationPassword=conformationPassword;
            if(Password!= conformationPassword)
            {
                throw new Password("Password entered doesnot match");
            }
            return u;
        }
        public static void Main()
        {
             try
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Password:");
                string Password = Console.ReadLine();

                Console.WriteLine("Enter Password again:");
                string conformationPassword = Console.ReadLine();

                User u  = ValidatePassword(name, Password, conformationPassword);
                Console.WriteLine("Payment successful");
            }
            catch (Password ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
                }
}