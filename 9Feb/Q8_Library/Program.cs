using System;
namespace Q8
{
    public class Author
    {
        public string AuthorName;
        public string Country;
        public Author(string name, string country)
        {
            this.AuthorName = name;
            this.Country = country;
        }
    }
    public class Book
    {
        public string Title;
        public int Price;
        public Author Author;
        public Book(string title, int price, Author author)
        {
            Title = title;
            Price = price;
            Author = author;
        }
        public void Display()
        {
            Console.WriteLine($"Title   : {Title}");
            Console.WriteLine($"Price   : {Price}");
            Console.WriteLine($"Author  : {Author.AuthorName}");
            Console.WriteLine($"Country : {Author.Country}");
            Console.WriteLine("----------------------------");
        }
    }
    class Progran
    {
        static void Main()
        {
            Console.WriteLine("\nLibrary Books:\n");

            Author a1 = new Author("George Orwell", "UK");
            Author a2 = new Author("Rabindranath Tagore", "India");

            Book b1 = new Book("1984", 499, a1);
            Book b2 = new Book("Gitanjali", 299, a2);

            b1.Display();
            b2.Display();
        }
    }
}