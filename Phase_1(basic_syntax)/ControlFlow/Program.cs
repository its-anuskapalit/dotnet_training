using System;
using System.Collections.Generic;

namespace ExecutionFlow
{
    class Order
    {
        public int Amount;
        public bool IsPriority;
    }

    class Program
    {
        static void Main()
        {
            var orders = new List<Order>
            {
                new Order { Amount = 200, IsPriority = false },
                new Order { Amount = 1200, IsPriority = true },
                new Order { Amount = 50, IsPriority = false }
            };

            int total = ProcessOrders(orders);

            Console.WriteLine(total);
        }

        static int ProcessOrders(List<Order> orders)
        {
            int total = 0;

            foreach (var order in orders)
            {
                if (order.Amount < 100)
                    continue;

                if (order.Amount > 1000 && !order.IsPriority)
                    return total;

                total += CalculateCharge(order.Amount);
            }

            return total;
        }

        static int CalculateCharge(int amount)
        {
            if (amount > 1000)
                return amount + 100;

            return amount + 20;
        }
    }
}
