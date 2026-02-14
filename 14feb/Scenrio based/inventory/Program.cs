using System;

namespace Inventory
{
    class Program
    {
        static void Main()
        {
            InventoryManager manager = new InventoryManager();

            while (true)
            {
                Console.WriteLine("\n1. Add Electronics");
                Console.WriteLine("2. Add Grocery");
                Console.WriteLine("3. Add Clothing");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Id: ");
                    string id = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Warranty (months): ");
                    int warranty = int.Parse(Console.ReadLine());

                    Console.Write("Power Usage: ");
                    int power = int.Parse(Console.ReadLine());

                    Console.Write("Manufacturing Date (yyyy-mm-dd): ");
                    DateTime mfg = DateTime.Parse(Console.ReadLine());

                    manager.AddProduct(
                        new Electronics(id, price, brand, model, warranty, power, mfg)
                    );
                }
                else if (choice == 2)
                {
                    Console.Write("Id: ");
                    string id = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Expiry Date (yyyy-mm-dd): ");
                    DateTime expiry = DateTime.Parse(Console.ReadLine());

                    Console.Write("Weight (kg): ");
                    double weight = double.Parse(Console.ReadLine());

                    Console.Write("Is Organic (true/false): ");
                    bool organic = bool.Parse(Console.ReadLine());

                    Console.Write("Storage Temperature: ");
                    double temp = double.Parse(Console.ReadLine());

                    manager.AddProduct(
                        new Grocery(id, price, expiry, weight, organic, temp)
                    );
                }
                else if (choice == 3)
                {
                    Console.Write("Id: ");
                    string id = Console.ReadLine();

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Size: ");
                    string size = Console.ReadLine();

                    Console.Write("Fabric: ");
                    string fabric = Console.ReadLine();

                    Console.Write("Gender: ");
                    string gender = Console.ReadLine();

                    Console.Write("Color: ");
                    string color = Console.ReadLine();

                    manager.AddProduct(
                        new Clothing(id, price, size, fabric, gender, color)
                    );
                }
                else if (choice == 4)
                {
                    manager.DisplayAllProducts();
                }
                else if (choice == 5)
                {
                    break;
                }
            }
        }
    }
}
