using System;

namespace Inventory
{
    public class Clothing : Product
    {
        public string Size { get; set; }
        public string FabricType { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }

        public Clothing(string id, decimal price, string size,
                        string fabric, string gender, string color)
            : base(id, price)
        {
            Size = size;
            FabricType = fabric;
            Gender = gender;
            Color = color;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"[Clothing] {Id} | Size: {Size} | Color: {Color} | Price: {Price}");
        }
    }
}
