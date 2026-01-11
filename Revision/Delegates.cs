namespace Delagate
{
    public delegate void Notify(string Message);
    class AlertService
    {
        public void Email(string msg)
        {
            Console.WriteLine("Email sent: "+msg);
        }
        public void SMS(string msg)
        {
            Console.WriteLine("SMS sent: "+msg);
        }   
    }
     public class Program
    {
        static void Main()
        {
            AlertService service=new AlertService();
            Notify ob;
            ob=service.Email;
            ob("Service Down");

            ob=service.SMS;
            ob("OTP 4579");
        }
}
}