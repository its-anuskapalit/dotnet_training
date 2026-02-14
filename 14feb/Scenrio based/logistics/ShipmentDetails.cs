using System;

namespace Logistics
{
    class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            if (ShipmentCode.Length == 7 && ShipmentCode.StartsWith("GC#") && int.TryParse(ShipmentCode.Substring(3), out _))
            {
                return true;
            }
            return false;
        }
        public double CalculateTotalCost()
        {
            double rate = 0;
            if (TransportMode == "Sea") rate = 15.00;
            else if (TransportMode == "Air") rate = 50.00;
            else if (TransportMode == "Land") rate = 25.00;
            double total = (Weight * rate) + Math.Sqrt(StorageDays);
            return Math.Round(total, 2);
        }
    }
}
