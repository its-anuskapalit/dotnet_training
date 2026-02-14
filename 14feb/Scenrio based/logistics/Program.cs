using System;

namespace Logistics
{
    class Program
    {
        static void Main()
        {
            ShipmentDetails shipment = new ShipmentDetails();
            Console.Write("Enter Shipment Code: ");
            shipment.ShipmentCode = Console.ReadLine();
            if (!shipment.ValidateShipmentCode())
            {
                Console.WriteLine("Invalid shipment code");
                return;
            }
            Console.Write("Enter Transport Mode: ");
            shipment.TransportMode = Console.ReadLine();
            Console.Write("Enter Weight: ");
            shipment.Weight = double.Parse(Console.ReadLine());
            Console.Write("Enter Storage Days: ");
            shipment.StorageDays = int.Parse(Console.ReadLine());
            double cost = shipment.CalculateTotalCost();

            Console.WriteLine($"The total shipping cost is {cost:F2}");
        }
    }
}
