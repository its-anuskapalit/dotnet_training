using System;
namespace BookStore
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            string id = input[0];
            string title = input[1];
            int price = int.Parse(input[2]);
            int stock = int.Parse(input[3]);
            Book book = new Book(id, title, price, stock);
            
            BookUtility utility = new BookUtility(book);

            while (true)
            {
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    utility.GetBookDetails();
                }
                else if (choice == 2)
                {
                    int newPrice = int.Parse(Console.ReadLine());
                    utility.UpdateBookPrice(newPrice);
                }
                else if (choice == 3)
                {
                    int newStock = int.Parse(Console.ReadLine());
                    utility.UpdateBookStock(newStock);
                }
                else if (choice == 4)
                {
                    break;
                }
            }
        }
    }
}
