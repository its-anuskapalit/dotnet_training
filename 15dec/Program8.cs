using System;
namespace Q8{
public class User
{
    public string? Name;
    public string? PhoneNumber;
}
public class PhoneNum : Exception
    {
        public PhoneNum(string message) : base(message) { }
    }
public class Program{
    public static User ValidatePhone(string name, string Phone)
        {
            User u=new User();
            u.Name=name;
            u.PhoneNumber=Phone;
            if(Phone.Length!= 10)
            {
                throw new PhoneNum("Invalid phone number");
            }
            return u;
        }
        public static void Main()
        {
             try
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Phonenumber:");
                string Phone = Console.ReadLine();

                User u  = ValidatePhone(name, Phone);
                Console.WriteLine("Validate successful");
            }
            catch (PhoneNum ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
                }
}