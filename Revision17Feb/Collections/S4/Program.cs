using System;
using System.Collections.Generic;

class TextEditor
{
    private Stack<string> actions = new Stack<string>();

    public void PerformAction(string action)
    {
        actions.Push(action);
        Console.WriteLine($"Performed: {action}");
    }

    public void Undo()
    {
        if (actions.Count > 0)
        {
            var lastAction = actions.Pop();
            Console.WriteLine($"Undone: {lastAction}");
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
}

class Program
{
    static void Main()
    {
        TextEditor editor = new TextEditor();

        editor.PerformAction("Typed Hello");
        editor.PerformAction("Typed World");

        editor.Undo();
        editor.Undo();
    }
}
