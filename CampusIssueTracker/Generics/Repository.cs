using System;
using System.Collections.Generic;
using System.Text;
namespace CampusIssueTracker.Generics
{
    public class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        // Method to get all items
        public List<T> GetAll()
        {
            return items;
        }
        // Boxing method
        public object BoxValue(int number) {
            object obj = number;
            return obj;
        
        }
        // Unboxing method
        public int UnboxValue(object obj) {
            int number = (int)obj;
            return number;
        }
    }
}
