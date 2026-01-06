using System;
using System.Collections.Generic;
using ItemsAlias = LibrarySystem.Items;

namespace LibrarySystem
{
    public enum UserRole { Admin, Librarian, Member }
    public enum ItemStatus { Available, Borrowed, Reserved, Lost }

    public interface IReservable
    {
        void Reserve();
    }

    public interface INotifiable
    {
        void Notify(string message);
    }

    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ItemID { get; set; }

        public abstract void DisplayItemDetails();
        public abstract double CalculateLateFee(int days);
    }

    namespace Items
    {
        public class Book : LibraryItem, IReservable, INotifiable
        {
            void IReservable.Reserve()
            {
                Console.WriteLine("Book reserved successfully.");
            }

            void INotifiable.Notify(string message)
            {
                Console.WriteLine("Notification: " + message);
            }

            public override void DisplayItemDetails()
            {
                Console.WriteLine("Item Type: Book");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double CalculateLateFee(int days)
            {
                return days * 1.0;
            }
        }

        public class Magazine : LibraryItem
        {
            public override void DisplayItemDetails()
            {
                Console.WriteLine("Item Type: Magazine");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double CalculateLateFee(int days)
            {
                return days * 0.5;
            }
        }

        public class eBook : LibraryItem
        {
            public void Download()
            {
                Console.WriteLine("eBook downloaded successfully.");
            }

            public override void DisplayItemDetails()
            {
                Console.WriteLine("Item Type: eBook");
                Console.WriteLine("Title: " + Title);
                Console.WriteLine("Author: " + Author);
                Console.WriteLine("Item ID: " + ItemID);
            }

            public override double CalculateLateFee(int days)
            {
                return 0;
            }
        }
    }

    public partial class LibraryAnalytics
    {
        public static int TotalBorrowed { get; set; }
    }

    public partial class LibraryAnalytics
    {
        public static void Display()
        {
            Console.WriteLine("Total Items Borrowed: " + TotalBorrowed);
        }
    }

    class Program
    {
        static void Main()
        {
            ItemsAlias.Book book = new ItemsAlias.Book { Title = "C# Fundamentals", Author = "John Doe", ItemID = 101 };
            ItemsAlias.Magazine mag = new ItemsAlias.Magazine { Title = "Tech Today", Author = "Jane Doe", ItemID = 201 };

            book.DisplayItemDetails();
            Console.WriteLine("Late Fee for 3 days: " + book.CalculateLateFee(3));

            mag.DisplayItemDetails();
            Console.WriteLine("Late Fee for 3 days: " + mag.CalculateLateFee(3));

            IReservable reservable = book;
            INotifiable notifiable = book;
            reservable.Reserve();
            notifiable.Notify("Your reserved book is ready for pickup.");

            List<LibraryItem> items = new List<LibraryItem> { book, mag };
            foreach (var item in items)
                item.DisplayItemDetails();

            LibraryAnalytics.TotalBorrowed = 5;
            LibraryAnalytics.Display();

            UserRole role = UserRole.Member;
            ItemStatus status = ItemStatus.Borrowed;
            Console.WriteLine("User Role: " + role);
            Console.WriteLine("Item Status: " + status);

            ItemsAlias.eBook ebook = new ItemsAlias.eBook { Title = "AI Guide", Author = "Sam", ItemID = 301 };
            ebook.Download();
        }
    }
}
