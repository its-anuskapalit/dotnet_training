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
}