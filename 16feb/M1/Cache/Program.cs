using System;
using System.Collections.Generic;

public class SimpleCache<TKey, TValue>
{
    private Dictionary<TKey, TValue> storage = new Dictionary<TKey, TValue>();
    public void Set(TKey key, TValue value)
    {
        storage[key] = value;
    }
    public TValue Get(TKey key)
    {
        if (storage.ContainsKey(key))
            return storage[key];
        return default(TValue);
    }
    public void Remove(TKey key)
    {
        if (storage.ContainsKey(key))
            storage.Remove(key);
    }
}
class Program
{
    static void Main()
    {
        SimpleCache<string, string> cache = new SimpleCache<string, string>();
        cache.Set("user1", "Anuska");
        Console.WriteLine(cache.Get("user1"));
        cache.Remove("user1");
        Console.WriteLine(cache.Get("user1")); 
    }
}
