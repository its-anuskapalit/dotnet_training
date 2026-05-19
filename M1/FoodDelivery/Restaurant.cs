using System;
namespace FoodDelivery
{
    public class Restaurant
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public bool IsOnline { get; set; }
    public int PreparationTimeMinutes { get; set; } // Average prep time
    public List<KitchenStation> KitchenStations { get; set; }
}

}