using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateExample
{
    public class ActionCls
    {
        
        public MathFunc FunctionPointer { get; set; }

       
        public void Execute()
        {
            int result = FunctionPointer(5, 10);
            Console.WriteLine($"The result is: {result}");
        }
       
    }
}
