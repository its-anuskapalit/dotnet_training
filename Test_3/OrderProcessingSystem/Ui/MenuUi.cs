using System;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem.UI
{
    /// <summary>
    /// Console based user interface for Order Processing System.
    /// </summary>
    public class MenuUI
    {
        private ProductRepository _productRepo;
        private OrderRepository _orderRepo;
        private OrderService _orderService;

        public MenuUI(ProductRepository p, OrderRepository o, OrderService s)
        {
            _productRepo = p;
            _orderRepo = o;
            _orderService = s;
        }

        public void Start()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("  Welcome to Online Order Processing");
            Console.WriteLine("======================================");

            bool exit = false;

            while (!exit)
            {
                try
                {
                    Console.WriteLine("\n1. View Products");
                    Console.WriteLine("2. Create Order");
                    Console.WriteLine("3. Change Order Status");
                    Console.WriteLine("4. View Orders Summary");
                    Console.WriteLine("5. Exit");
                    Console.Write("Select option: ");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: ViewProducts(); break;
                        case 2: CreateOrder(); break;
                        case 3: ChangeStatus(); break;
                        case 4: ViewOrders(); break;
                        case 5: exit = true; break;
                        default: Console.WriteLine("Invalid option."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("Thank you for using the system.");
        }

        private void ViewProducts()
        {
            Console.WriteLine("\n--- Available Products ---");
            foreach (var p in _productRepo.GetAll().Values)
                Console.WriteLine($"{p.Id}. {p.Name} - Rs {p.Price}");
        }

        private void CreateOrder()
        {
            Console.Write("\nEnter Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Id: ");
            int custId = int.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string custName = Console.ReadLine();

            Customer cust = new Customer(custId, custName);
            Order order = new Order(orderId, cust);

            while (true)
            {
                ViewProducts();
                Console.Write("Enter Product Id (0 to finish): ");
                int pid = int.Parse(Console.ReadLine());
                if (pid == 0) break;

                Console.Write("Enter Quantity: ");
                int qty = int.Parse(Console.ReadLine());

                Product p = _productRepo.GetById(pid);
                order.Items.Add(new OrderItem(p, qty));
            }

            _orderRepo.Add(order);
            Console.WriteLine("Order created successfully.");
        }

        private void ChangeStatus()
        {
            Console.Write("Enter Order Id: ");
            int id = int.Parse(Console.ReadLine());

            Order order = _orderRepo.GetById(id);

            Console.WriteLine("Select new status:");
            foreach (var s in Enum.GetValues(typeof(OrderStatus)))
                Console.WriteLine($"{(int)s} - {s}");

            OrderStatus status = (OrderStatus)int.Parse(Console.ReadLine());

            _orderService.ChangeStatus(order, status);
        }

        private void ViewOrders()
        {
            Console.WriteLine("\n============= ORDER SUMMARY REPORT =============");

            foreach (var o in _orderRepo.GetAll().Values)
            {
                Console.WriteLine($"\nOrder ID: {o.Id}");
                Console.WriteLine($"Customer : {o.Customer.Name}");
                Console.WriteLine($"Status   : {o.CurrentStatus}");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Item\t\tPrice\tQty\tTotal");

                decimal grandTotal = 0;

                foreach (var item in o.Items)
                {
                    decimal lineTotal = item.GetTotal();
                    grandTotal += lineTotal;

                    Console.WriteLine($"{item.Product.Name}\t{item.Product.Price}\t{item.Quantity}\t{lineTotal}");
                }

                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"GRAND TOTAL : Rs {grandTotal}");
                Console.WriteLine("\n--- Status Timeline ---");

                foreach (var h in o.History)
                {
                    Console.WriteLine($"{h.ChangedOn} | {h.OldStatus} -> {h.NewStatus}");
                }

                Console.WriteLine("==============================================");
            }
        }
    }
}
