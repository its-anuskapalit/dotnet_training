using System;

public delegate void LogHandler(string message);

class Calculator
{
    public void Add(int a, int b, LogHandler logHandler)
    {
        int result = a + b;

        logHandler($"Result is {result}");
    }
}

class Program
{
    static void ConsoleLogger(string message)
    {
        Console.WriteLine("Log: " + message);
    }

    static void Main()
    {
        Calculator calc = new Calculator();

        calc.Add(5, 10, ConsoleLogger);
    }
}
