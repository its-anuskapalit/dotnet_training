using OrderProcessingSystem.Data;
using OrderProcessingSystem.Services;
using OrderProcessingSystem.UI;

class Program
{
    static void Main()
    {
        ProductRepository productRepo = new ProductRepository();
        OrderRepository orderRepo = new OrderRepository();
        OrderService orderService = new OrderService();

        orderService.OnStatusChanged += new CustomerNotificationService().Notify;
        orderService.OnStatusChanged += new LogisticsNotificationService().Notify;

        MenuUI menu = new MenuUI(productRepo, orderRepo, orderService);
        menu.Start();
    }
}
