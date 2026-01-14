using System.Collections.Generic;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Data
{
    /// <summary>
    /// Stores all orders in memory and provides access methods.
    /// </summary>
    public class OrderRepository
    {
        private Dictionary<int, Order> _orders = new Dictionary<int, Order>();

        public Dictionary<int, Order> GetAll()
        {
            return _orders;
        }

        public void Add(Order order)
        {
            if (!_orders.ContainsKey(order.Id))
                _orders.Add(order.Id, order);
        }

        public Order GetById(int id)
        {
            return _orders.ContainsKey(id) ? _orders[id] : null;
        }
    }
}
