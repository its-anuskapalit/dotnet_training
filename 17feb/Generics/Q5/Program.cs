using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        try{
        var nums = new List<int> { 2, 5, 8, 11, 14 };

        var evens = Filter(nums, n => n % 2 == 0);
        Console.WriteLine(string.Join(",", evens));         // Expected: 2,8,14

        var big = Filter(nums, n => n >= 10);
        Console.WriteLine(string.Join(",", big));  
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error!!");
        }         // Expected: 11,14
    }

    // ✅ TODO: Students implement only this function
    public static List<T> Filter<T>(List<T> items, Predicate<T> match)
    {
        if (match == null)
        {
            throw new ArgumentException();
        }
        // TODO: return a new list with matched items
        List<T> result = new List<T>();
        if(items== null)
        {
            return default;
        }
        foreach (var item in items)
        {
            if (match(item))
            {
                result.Add(item);
            }
        }
        return result.Count==0? default:result;
    }
}