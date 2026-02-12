using System;
using System.Linq;
using System.Reflection;

interface IPlugin
{
    string Key { get; }
}

class PluginA : IPlugin
{
    public string Key => "PluginA";
}

class PluginB : IPlugin
{
    public string Key => "PluginB";
}

class Program
{
    static void Main()
    {
        var plugins = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

        foreach (var p in plugins)
            Console.WriteLine(((IPlugin)Activator.CreateInstance(p)).Key);
    }
}
