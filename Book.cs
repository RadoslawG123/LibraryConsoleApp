using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public abstract class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public float Price { get; private set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            Price = 0;
        }

        public abstract void DisplayInfo();

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
    }
}
