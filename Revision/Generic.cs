namespace Generic{
class DataBox<T>
{
    public T Value;
}
class Program
    {
        public static void Main()
        {
            DataBox<int> a=new DataBox<int>();
            a.Value=100;
            Console.WriteLine(a.Value);
            DataBox<string> b=new DataBox<string>();
            b.Value="Anuska";
            Console.WriteLine(b.Value);
        }
    }
}