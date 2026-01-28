using System;
using System.Collections.Generic;

namespace BakeMeWish
{
    class Program
    {
        static void AddOrderDetails(Dictionary<string, int> orderDetails)
        {
            Console.WriteLine("Enter order id: ");
            string orderId = Console.ReadLine();

            Console.WriteLine("Enter order cost: ");
            int orderCost = Convert.ToInt32(Console.ReadLine());

            orderDetails.Add(orderId, orderCost);
        }

        static Dictionary<string, int> FindOrdersAboveCost(Dictionary<string, int> orderDetails, double cakeCost)
        {
            Dictionary<string, int> filteredOrders = new Dictionary<string, int>();

            foreach (var order in orderDetails)
            {
                if (order.Value > cakeCost)
                {
                    filteredOrders.Add(order.Key, order.Value);
                }
            }

            return filteredOrders;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of orders: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, int> orderDetails = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                AddOrderDetails(orderDetails);
            }

            Console.WriteLine("Enter cake cost to filter orders: ");
            double cakeCost = Convert.ToDouble(Console.ReadLine());

            Dictionary<string, int> filteredOrders =
                FindOrdersAboveCost(orderDetails, cakeCost);

            Console.WriteLine("Orders with cost above " + cakeCost + ":");

            foreach (var order in filteredOrders)
            {
                Console.WriteLine("Order ID: " + order.Key + ", Cost: " + order.Value);
            }
        }
    }
}
