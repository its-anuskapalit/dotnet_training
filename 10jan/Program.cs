class Program
{
    static void Main()
    {
        NotificationService service = new NotificationService();
        //Created a function container
        Notify notifier;
        // //Stored method reference
        // notifier = service.SendEmail;
        // notifier("Server Down");
        // //Executed method dynamically
        // notifier = service.SendSMS;
        // notifier("OTP 4567");

        notifier = service.SendSMS;
        notifier+=service.Push;
        notifier("Order placed");
    }
}
