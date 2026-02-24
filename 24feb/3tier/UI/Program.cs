using ClassBL;
namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlRevstring bl = new BlRevstring();
           string s= bl.Revstring();
            Console.WriteLine(s);

        }
    }
}
