using System;

namespace MoreInterfaceExamples;

public static class Demo_IConvertible
{
    public static void Run()
    {
        Console.WriteLine("---- 2) IConvertible Demo ----");

        object value = 123; // boxed int implements IConvertible
        if (value is IConvertible c)
        {
            double asDouble = c.ToDouble(null);
            string asString = c.ToString(null);
            Console.WriteLine($"As double: {asDouble}");
            Console.WriteLine($"As string: {asString}");
        }

        Console.WriteLine($"Convert.ToInt32('9') => {Convert.ToInt32('9')}");
        Console.WriteLine($"Convert.ToDateTime('2026-02-11') => {Convert.ToDateTime("2026-02-11"):yyyy-MM-dd}");

        Console.WriteLine();
    }
}
