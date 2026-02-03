namespace DelegateExample
{
    public delegate int MathFunc(int x, int y);
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ActionCls actionCls = new ActionCls();

            actionCls.FunctionPointer = new MathFunc((x, y) => x + y);
            actionCls.Execute();
        }
    }
}
