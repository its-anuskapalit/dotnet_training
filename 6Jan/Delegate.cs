using System;
namespace LearningCSharp
{
    public delegate int DelegateAddFunctionName  (int a, int b);
    public class ExampleOfDelegate
    {
        public int a;
        public int b;
        public void DelegateEx1()
        {
            DelegateAddFunctionName delegateVarable = new DelegateAddFunctionName(AddMethod2);
            Console.WriteLine(delegateVarable(1, 2));
        }
        public void DelegateEx2()
        {
            DelegateAddFunctionName delegateVarable = new DelegateAddFunctionName(SubMethod2);
            Console.WriteLine(delegateVarable(1, 2));
        }
        public int SubMethod2(int a ,int b)
        {
            return a-b;
        }

        private int AddMethod3(int a, int b)
        {
            return a + b +40;
        }
        private int AddMethod2(int a, int b)
        {
            return a + b + 10;
        }
    }
    class Program
    {
        public static void Main()
        {
            ExampleOfDelegate ob=new ExampleOfDelegate();
            ob.DelegateEx1();
            ob.DelegateEx2();
        }
    }
}