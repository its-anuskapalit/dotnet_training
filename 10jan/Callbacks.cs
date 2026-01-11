using System;
namespace Delegate{
public delegate void PaymentStatus(string message);
class PayementGateway
{
    public void MakePayment(decimal amt, PaymentStatus callback)
    {
        Console.WriteLine("Processing payment of " + amt);
        callback("Payment successful for Rs." + amt);

    }
}
class NotificationService
{
    public void NotifyUser(string msg)
    {
        Console.WriteLine("NOTIFICATION: " + msg);
    }
}
class Program
    {
        static void Main()
        {
            PayementGateway gateway=new PayementGateway();
            NotificationService service=new NotificationService();

            PaymentStatus status= service.NotifyUser;
            gateway.MakePayment(2500,status);
        }
    }
}