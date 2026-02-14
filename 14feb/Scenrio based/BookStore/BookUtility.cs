using System;
namespace BookStore
{
    public class BookUtility
    {
        private Book b;
        public BookUtility(Book book)
        {
            b=book;
        }
        public void GetBookDetails()
        {
            Console.WriteLine($"{b.Id} {b.Title} {b.Price}");
        }
        public void UpdateBookPrice(int newPrice)
        {
            b.Price=newPrice;
        }
        public void UpdateBookStock(int newStock)
        {
            b.Stock=newStock;
        }
    }
}