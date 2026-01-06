using System;
namespace LearningCSharp
{
    public class Example
    {
         public void DelegateEx2()
        {
            DelegateAddFunctionName delegateVarable = new DelegateAddFunctionName(SubMethod2);
            Console.WriteLine(delegateVarable(10, 2));
        }
        public int SubMethod2(int a ,int b)
        {
            return a-b;
        }
    }
    class Pro
    {
        public static void Main()
        {
            Example ob=new Example();
            ob.DelegateEx2();
        }
    }
}