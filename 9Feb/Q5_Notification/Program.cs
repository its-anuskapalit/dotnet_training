using System;
namespace Q5
{
    public interface INotifier
    {
        public void Send(string msg);
    }
    public class EmailNotifier: INotifier
    {
        public void Send(string msg)
        {
            Console.WriteLine($"{msg} from email");
        }
    }
    public class SmsNotifier: INotifier
    {
        public void Send(string msg)
        {
            Console.WriteLine($"{msg} from Sms");
        }
    }
    public class WhatsAppNotifier: INotifier
    {
        public void Send(string msg)
        {
            Console.WriteLine($"{msg} from WhatsApp");
        }
    }
    class Program
    {
        static void Main()
        {
            List<INotifier> notifiers=new List<INotifier>
            {
                new EmailNotifier(),
                new SmsNotifier(),
                new WhatsAppNotifier()
            };
            foreach(var notice in notifiers)
            {
                notice.Send("Alert!!");
            }
        }
    }

}