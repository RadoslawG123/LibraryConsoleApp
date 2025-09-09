using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool Available { get; private set; }
        public float Price { get; private set; }

        public Book(string title, string author) 
        {
            Title = title;
            Author = author;
            Price = 0;
            Available = true;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            if (Available)
                Console.WriteLine("Avaible: YES");
            else
                Console.WriteLine("Avaible: NO");
            Console.WriteLine("Price: " + Price + "$");
            Console.WriteLine("--------------------------------------------------------------");
        }

        public void setTitle(string title)
        {
            if (title.Length == 0)
            {
                Console.WriteLine("Title should have at least 1 character. Please try again.");
                return;
            }

            Title = title;
            Console.WriteLine($"Title {title} is setted successfully.");
        }

        public void setAuthor(string author)
        {
            if (author.Length == 0)
            {
                Console.WriteLine("Author should have at least 1 character. Please try again.");
                return;
            }

            Author = author;
            Console.WriteLine($"Author {author} is setted successfully.");
        }

        public void setPrice(string title, float price) 
        {
            if (price < 0)
            {
                Console.WriteLine("Price shouldn't be lower than 0$. Please try again.");
                return;
            }
            
            Price = price;

            Console.WriteLine("Price is setted successfully for '" + title + "'.");
        }

        public void changeAvailability()
        {
            Console.WriteLine($"Availability is changed from {!Available} to {Available}");
        }
    }
}
