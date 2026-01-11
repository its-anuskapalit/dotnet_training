    using Delagate;
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