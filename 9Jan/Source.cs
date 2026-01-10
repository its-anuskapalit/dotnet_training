namespace Q2
{
    class Source
    {
        public int Add(int a, int b)
        {
            return a+b;
        }
         public double Add(double a, double b,double c)
        {
            return a+b+c;
        }
    }
    class Program
    {
        static void Main()
        {
            Source ob=new Source();
            Console.WriteLine(ob.Add(4,5));
            Console.WriteLine(ob.Add(0.5,1.5,0.2));
        }
    }
}