using System;
public class Program
{
    public static SortedDictionary<string ,long> ItemDetails=new SortedDictionary<string, long>();
    public static SortedDictionary<string ,long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result=new SortedDictionary<string, long>();
        foreach(var i in ItemDetails)
        {
            if (i.Value == soldCount)
            {
                result.Add(i.Key, i.Value);
            }
        }
        return result;
    }
    public static List<string> FindMinandMinItems()
    {
        var min=ItemDetails.Values.Min();
        var max=ItemDetails.Values.Max();
        List<string> result=new List<string>();
        foreach(var i in ItemDetails)
        {
            if(i.Value==min || i.Value == max)
            {
                result.Add(i.Key + " : " + i.Value);
            }
        }
        return result;
    }
    public static Dictionary<string,long> SortByCount()
    {
        var idCollections = ItemDetails
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

        return idCollections;
                
    }
    public static void Main()
    {
        Console.WriteLine("Enter the total items need to be add:");
        int total=int.Parse(Console.ReadLine());
        for(int i = 0; i < total; i++)
        {
            Console.WriteLine("Enter the items name:");
            String item=Console.ReadLine();
            Console.WriteLine("Enter the sold count:");
            int sold=int.Parse(Console.ReadLine());
            ItemDetails.Add(item,sold);
        }
        Console.WriteLine("======================Enter the sold count to be seach======================");
        long Count=long.Parse(Console.ReadLine());
        var matchedItems= FindItemDetails(Count);
        Console.WriteLine("|| Items with given sold count: ||");
        if (matchedItems.Count() == 0)
        {
            Console.WriteLine("No item found.");
        }
        else
        {
            foreach(var item in matchedItems)
            {
                Console.WriteLine(item.Key + " : " + item.Value); 
            }
        }
        Console.WriteLine("======================Min & Max sold items:======================");
        var maxmin= FindMinandMinItems();
         foreach(var item in maxmin)
        {
           Console.WriteLine(item); 
        }
         Console.WriteLine("======================Items sorted by sold count (Descending):======================");
         var sorted= SortByCount();
         foreach(var item in sorted)
        {
           Console.WriteLine(item.Key + " : " + item.Value); 
        }
    }
}