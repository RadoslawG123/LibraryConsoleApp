using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryConsoleApp
{
    internal class Library
    {
        public static void Main()
        {
            int input = -1;
            List<Book> Books = [];

            while (true) 
            {
                Console.Write("""
                
                Welcome to the library!

                Options:
                1. Show all Books
                2. Add new Book
                3. Edit Book's Data
                4. Delete Book
                5. Exit

                Choice: 
                """);

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("""
                        --------------------------------------------------------------
                        Incorrect choice!
                        You can type a choice as a single digit between numbers: 1-5.
                        Please try again.
                        --------------------------------------------------------------
                        """);
                } 

                // Show all books
                if (input == 1)
                {
                    if (Books.Count != 0) 
                    {
                        Console.WriteLine("""
                        All books in the library:

                        """);
                        foreach (Book book in Books)
                        {
                            book.DisplayInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("We don't have any book in our library. Please add one if you have.");
                    }
                }
                // Add new book
                if(input == 2)
                {
                    string titleInput;
                    string authorInput;
                    float priceInput;

                    Console.Write("Provide TITLE for the book: ");
                    titleInput = Console.ReadLine();

                    Console.Write("Provide AUTHOR of the book: ");
                    authorInput = Console.ReadLine();
                    Books.Add(new Book(titleInput, authorInput));

                    Console.Write("Provide BORROW PRICE for the book: ");
                    priceInput = float.Parse(Console.ReadLine());
                    Books.FirstOrDefault(b => b.Title == titleInput).setPrice(titleInput, priceInput);

                    Console.WriteLine("Book '" + titleInput + "' has added sucesfully.");
                }
                // Edit data of existing book
                if (input == 3) 
                {
                    string titleInput;
                    Console.Write("What book you want to edit(Provide a title): ");
                    titleInput = Console.ReadLine();

                    Book book = Books.Find(b => b.Title == titleInput);
                    Console.WriteLine("Book details:");
                    book.DisplayInfo();
                    Console.WriteLine("What do you want to change?");
                    ////////////////////// Last work is here !

                }
                // Exit
                if(input == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    break;
                }

                //Console.Clear();
            }
        }
    }
}
