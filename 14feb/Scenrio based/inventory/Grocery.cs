using System;

namespace Inventory
{
    public class Grocery : Product
    {
        public DateTime ExpiryDate { get; set; }
        public double Weight { get; set; }
        public bool IsOrganic { get; set; }
        public double StorageTemperature { get; set; }

        public Grocery(string id, decimal price, DateTime expiry,
                       double weight, bool organic, double temp)
            : base(id, price)
        {
            ExpiryDate = expiry;
            Weight = weight;
            IsOrganic = organic;
            StorageTemperature = temp;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Grocery] {Id} | Expires: {ExpiryDate.ToShortDateString()} | Price: {Price} | Organic: {IsOrganic}");
        }
    }
}
