using System;
public delegate void Notify(string message);
class NotificationService
{
    public void SendEmail(string msg)
    {
        Console.WriteLine("EMAIL SENT: " + msg);
    }
    public void SendSMS(string msg)
    {
        Console.WriteLine("SMS SENT: " + msg);
    }
    public void Push(string msg)
    {
        Console.WriteLine("PUSH: " + msg);
    }
}
