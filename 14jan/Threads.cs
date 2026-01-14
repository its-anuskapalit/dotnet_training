using System;
using System.Threading;
namespace Threading
{
    public class ThreadingEx
    {
        public static void RunStep1()
        {
            Console.WriteLine("For Loop for Even");
            for(int i = 0; i < 50; i += 2)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }
        }
        public static void RunStep2()
        {
            Console.WriteLine();
            Console.WriteLine("For Loop for Odd");
            for(int i = 1; i < 50; i += 2)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }
        }
        public static void Main()
        {
            Thread t1 = new Thread(RunStep1);
            Thread t2 = new Thread(RunStep2);
            t1.Start();
            t1.Join();
            Thread.Sleep(3000);
            Console.WriteLine();
            t2.Start();
        }
    }
}
