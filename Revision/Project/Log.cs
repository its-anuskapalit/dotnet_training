namespace Project
{
    public interface ILogger
    {
        void Log(string msg);
    }
    public class ConsolerLogger: ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine("MSG: "+msg);
        }
    }
}