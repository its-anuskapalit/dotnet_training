using System;

namespace Inventory
{
    public class Electronics : Product
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int WarrantyPeriod { get; set; }
        public int PowerUsage { get; set; }
        public DateTime ManufacturingDate { get; set; }

        public Electronics(string id, decimal price, string brand, string model,
                           int warranty, int powerUsage, DateTime mfgDate)
            : base(id, price)
        {
            Brand = brand;
            Model = model;
            WarrantyPeriod = warranty;
            PowerUsage = powerUsage;
            ManufacturingDate = mfgDate;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Electronics] {Id} | {Brand} {Model} | Price: {Price} | Warranty: {WarrantyPeriod} months");
        }
    }
}
