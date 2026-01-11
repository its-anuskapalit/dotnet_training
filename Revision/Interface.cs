public interface ILogger
{
    void Log(string msg);
}
public class FileLogger : ILogger
{
    public void Log(string msg)
    {
        Console.WriteLine ("Filer log: "+msg);
    }
}