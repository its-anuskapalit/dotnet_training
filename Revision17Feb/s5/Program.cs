// using System;
// class Program
// {
//     static void Main()
//     {
//         DateTime inputDate = DateTime.Parse(Console.ReadLine());
//         string result = inputDate.ToString("yyyyMMdd");
//         Console.WriteLine(result);
//         decimal amount = 12.3456m;

//         Console.WriteLine(amount.ToString("F2"));
//         double num = 12.3456;

//         Console.WriteLine($"{num:F2}");

//         Func<int, int, double> area = (a, b) => (a + b) * 0.5;
//         Console.WriteLine(area(2, 3));
//         Func<int, int, double> area2 = Area2;
//         Console.WriteLine(area2(2, 3));

//         Predicate<int> isEven = a => a % 2 == 0;
//         List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };
//         foreach (int i in list)
//         {
//             if (isEven(i))
//             {
//                 Console.WriteLine($"{i} is Even");
//             }
//             else
//             {
//                 Console.WriteLine($"{i} is Odd");
//             }
//         }

//         List<int> list2 = new List<int> { 7, 8, 9, 10, 11, 12 };
//         Predicate<int> iseven2 = isEven2;
//         foreach (int i in list2)
//         {
//             if (iseven2(i))
//             {

//                 Console.WriteLine($"{i} is Even");
//             }
//             else
//             {
//                 Console.WriteLine($"{i} is Odd");
//             }
//         }
//         Action<string> greet = str => Console.WriteLine($"Hello {str}");
//         Action<string> greet2 = Greet;
//         greet("Anuska");
//         greet2("Polly");
//     }

//     static double Area2(int a, int b)
//     {
//         return a * b * 0.6;
//     }
//     static bool isEven2(int i)
//     {
//         return i % 2 == 0;
//     }
//     static void Greet(string str)
//     {
//         Console.WriteLine($"Hello {str}");
//     }
// }

// using System;
// class Publisher
// {
//     public event Action OnProcessCompleted;
//     public void Start()
//     {
//          Console.WriteLine("Process Started");
//          OnProcessCompleted?.Invoke();
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Publisher pub=new Publisher();
//         pub.OnProcessCompleted += ProcessFinished;
//         pub.Start();
//     }
//     static void ProcessFinished()
//     {
//         Console.WriteLine("Process Completed!");
//     }
// }

// using System;
// class Order
// {
//     public delegate void OrderPlaced(string product);
//     public event OrderPlaced onOrderPlaced;
//     public void PlaceOrder(string product)
//     {
//         Console.WriteLine($"Order placed for product {product}");
//         onOrderPlaced?.Invoke(product);
//     }
// }
// class Program
// {
//     static void SendEmail(string product)
//     {
//         Console.WriteLine($"Email for comfimation send for product {product}");
//     }
//     static void SendInvoice(string product)
//     {
//         Console.WriteLine($"Invoice send for product {product}");
//     }
//     static void Main()
//     {
//         Order order=new Order();
//         order.onOrderPlaced+=SendEmail;
//         order.onOrderPlaced+=SendInvoice;
//         order.PlaceOrder("I-Phone");
//     }
// }

// using System;
// class Process
// {
//     public event EventHandler processComplete;
//     public void Start()
//     {
//         Console.WriteLine("Processing...");
//         processComplete?.Invoke(this,EventArgs.Empty);
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Process p = new Process();
//         p.processComplete += OnProcessCompleted;
//         p.Start();
//     }

//     static void OnProcessCompleted(object sender, EventArgs e)
//     {
//         Console.WriteLine("Process Finished!");
//     }
// }

// using System;
// class OrderEventArgs : EventArgs
// {
//     public string ProductName { get; set; }
//     public int Quantity { get; set; }
// }
// class Order
// {
//     public event EventHandler<OrderEventArgs> OrderPlaced;
//     public void PlaceOrder(string product, int qty)
//     {
//         Console.WriteLine("Order placed.");
//         OrderPlaced?.Invoke(this,
//             new OrderEventArgs
//             {
//                 ProductName = product,
//                 Quantity = qty
//             });
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Order order = new Order();
//         order.OrderPlaced += OnOrderPlaced;
//         order.PlaceOrder("Laptop", 2);
//     }
//     static void OnOrderPlaced(object sender, OrderEventArgs e)
//     {
//         Console.WriteLine($"Product: {e.ProductName}");
//         Console.WriteLine($"Quantity: {e.Quantity}");
//     }
// }


using System;
class Program
{
    static void Main()
    {
        string input=Console.ReadLine();
        if (IsIPAddress(input))
            Console.WriteLine("IP Address");
        else if (IsMacAddress(input))
            Console.WriteLine("MAC Address");
        else if (IsCurrency(input))
            Console.WriteLine("Currency");
        else if (IsDate(input))
            Console.WriteLine("Date");
        else
            Console.WriteLine("Invalid");
    }
    static bool IsDate(string input)
    {
        return DateTime.TryParse(input,out _);
    }
    static bool IsIPAddress(string input)
    {
        string[] part=input.Split('.');
        if (part.Length != 4)
        {
            return false;
        }
        foreach(string i in parts)
        {
            if(!int.TryParse(part,out int num)) return false;
            if(i < 0 || i >255) return false;
        }
        return true;
    }
    static bool IsMacAddress(string inputs)
    {
        string[] parts=inputs.Split(':');
        if(parts.Length!=6) return false;
        string check="0123456789ABCDEFabcdef";
        foreach(var i in parts)
        {
            if(i.Length!=2) return false;
            foreach(char c in i)
            {
                if (!check.Contains(c))
                {
                    return false;
                }
            }
        }
        return true;
    }

}