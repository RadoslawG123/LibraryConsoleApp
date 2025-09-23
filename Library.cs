using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LibraryConsoleApp
{
    internal class Library
    {
        public static void Main()
        {
            int input = -1;
            bool exit = false;
            List<Book> Books = [];

            while (!exit) 
            {
                Console.Write("""
                
                Welcome to the library!

                What do you want to manage:
                1. Books
                2. Ebooks

                >>  
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
                        You can type a choice as a single digit between numbers: 1-2.
                        Please try again.
                        --------------------------------------------------------------
                        """);
                }

                if (input == 1) 
                {
                    while (true)
                    {
                        Console.Write("""
                
                            Welcome to the Book managment!

                            Options:
                            1. Show all Books
                            2. Add new Book
                            3. Edit Book's Data
                            4. Delete Book
                            5. Exit application
                            6. Back

                            >>  
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
                        You can type a choice as a single digit between numbers: 1-6.
                        Please try again.
                        --------------------------------------------------------------
                        """);
                        }

                        // 1. Show all books
                        if (input == 1)
                            ShowBook(Books);

                        // 2. Add new book
                        if (input == 2)
                            AddBook(Books);

                        // 3. Edit data of existing book
                        if (input == 3)
                            EditBook(Books);

                        // 4. Delete Book
                        if (input == 4)
                            DeleteBook(Books);

                        // 5. Exit
                        if (input == 5)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Goodbye!");
                            exit = true;
                            break;
                        }

                        // 6. Back
                        if (input == 6)
                            break;

                        //Console.Clear();
                    }
                }
                else if (input == 2)
                {
                    // Ended work here!
                }
            }
        }

        // Option Functions
        
        // Show Book
        public static void ShowBook(List<Book> books)
        {
            if (books.Count != 0)
            {
                Console.WriteLine("""
                        All books in the library:

                        """);
                foreach (Book book in books)
                {
                    book.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("We don't have any book in our library. Please add one if you have.");
            }
        }

        // Add Book
        public static void AddBook(List<Book> books)
        {
            string titleInput;
            string authorInput;
            float priceInput;

            Console.Write("""
                        Provide TITLE for the book: 
                        >> 
                        """);
            titleInput = Console.ReadLine();

            Console.Write("""
                        Provide AUTHOR of the book: 
                        >> 
                        """);
            authorInput = Console.ReadLine();
            books.Add(new Book(titleInput, authorInput));

            Console.Write("""
                        Provide BORROW PRICE for the book: 
                        >> 
                        """);
            priceInput = float.Parse(Console.ReadLine());
            books.FirstOrDefault(b => b.Title == titleInput).setPrice(titleInput, priceInput);

            Console.WriteLine("Book '" + titleInput + "' has added sucesfully.");
        }

        // Edit Book
        public static void EditBook(List<Book> books)
        {
            string titleInput;
            string userChoice = "";
            Console.Write("""
                        What book you want to edit(Provide a title): 
                        >> 
                        """);
            titleInput = Console.ReadLine();

            Book book = books.Find(b => b.Title.ToLower() == titleInput.ToLower());

            while (userChoice != "5" && userChoice.ToLower() != "exit")
            {
                Console.WriteLine("Book details:");
                book.DisplayInfo();
                Console.WriteLine("What do you want to change?");
                Console.Write("""
                        Options:

                        1. Title
                        2. Author
                        3. Availibility
                        4. Price
                        5. Exit

                        >> 
                        """);
                userChoice = Console.ReadLine();
                if (userChoice == "1" || userChoice.ToLower() == "title")
                {
                    string newTitle;

                    Console.Write("""
                            Provide new title
                            >> 
                            """);
                    newTitle = Console.ReadLine();
                    book.setTitle(newTitle);
                }
                else if (userChoice == "2" || userChoice.ToLower() == "author")
                {
                    string newAuthor;

                    Console.Write("""
                            Provide new author name
                            >> 
                            """);
                    newAuthor = Console.ReadLine();
                    book.setAuthor(newAuthor);
                }
                else if (userChoice == "3" || userChoice.ToLower() == "availability")
                {
                    book.changeAvailability();
                }
                else if (userChoice == "4" || userChoice.ToLower() == "price")
                {
                    float newPrice;

                    Console.Write("""
                            Provide new price
                            >> 
                            """);
                    newPrice = float.Parse(Console.ReadLine());
                    book.setPrice(book.Title, newPrice);
                }
            }
        }

        // Delete Book
        public static void DeleteBook(List<Book> books)
        {
            string titleInput;
            string userChoice = "";
            Console.Write("""
                        What book you want to remove(Provide a title): 
                        >> 
                        """);
            titleInput = Console.ReadLine();

            books.Remove(books.Find(b => b.Title.ToLower() == titleInput.ToLower()));

            Console.Write($"The book has been removed from library.");
        }
    }
}
