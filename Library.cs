using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
            List<PhysicalBook> Books = [];
            List<Ebook> Ebooks = [];

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
                    if (input != 1 && input != 2) 
                    {
                        Console.WriteLine("""
                        --------------------------------------------------------------
                        Incorrect choice!
                        You can type a choice as a single digit between numbers: 1-2.
                        Please try again.
                        --------------------------------------------------------------
                        """);
                    }

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
                
                            Welcome to the Books managment!

                            Options:
                            1. Show all Books
                            2. Add new Book
                            3. Edit Book's Data
                            4. Delete Book
                            5. Exit application
                            6. Back

                            >>  
                            """);

                        string rawInput = Console.ReadLine();

                        if (!int.TryParse(rawInput, out input) || input < 1 || input > 6)
                        {
                            Console.WriteLine("""
                        --------------------------------------------------------------
                        Incorrect choice!
                        You can type a choice as a single digit between numbers: 1-6.
                        Please try again.
                        --------------------------------------------------------------
                        """);
                            continue;
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

                        // 4. Delete PhysicalBook
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
                    while (true)
                    {
                        Console.Write("""
                
                            Welcome to the Ebooks managment!

                            Options:
                            1. Show all Ebooks
                            2. Add new Ebook
                            3. Edit EBook's Data
                            4. Delete EBook
                            5. Exit application
                            6. Back

                            >>  
                            """);

                        string rawInput = Console.ReadLine();

                        if (!int.TryParse(rawInput, out input) || input < 1 || input > 6)
                        {
                            Console.WriteLine("""
                        --------------------------------------------------------------
                        Incorrect choice!
                        You can type a choice as a single digit between numbers: 1-6.
                        Please try again.
                        --------------------------------------------------------------
                        """);
                            continue;
                        }

                        // 1. Show all books
                        if (input == 1)
                            ShowBook(Ebooks);

                        // 2. Add new book
                        if (input == 2)
                            AddBook(Ebooks);

                        // 3. Edit data of existing book
                        if (input == 3)
                            EditBook(Ebooks);

                        // 4. Delete PhysicalBook
                        if (input == 4)
                            DeleteBook(Ebooks);

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
            }
        }

        // Option Functions

        // Show PhysicalBook
        public static void ShowBook(IEnumerable<Book> data)
        {
            // Books
            if (data is List<PhysicalBook> books)
            {
                if (books.Count != 0)
                {
                    Console.WriteLine("""
                        All books in the library:

                        """);
                    foreach (PhysicalBook book in books)
                    {
                        book.DisplayInfo();
                    }
                }
                else
                {
                    Console.WriteLine("We don't have any book in our library. Please add one if you have.");
                }
            }


            // Ebooks
            else if (data is List<Ebook> ebooks)
            {
                if (ebooks.Count != 0)
                {
                    Console.WriteLine("""
                        All Ebooks in the library:

                        """);
                    foreach (Ebook ebook in ebooks)
                    {
                        ebook.DisplayInfo();
                    }
                }
                else
                {
                    Console.WriteLine("We don't have any Ebook in our library. Please add one if you have.");
                }
            }
        }

        // Add PhysicalBook
        public static void AddBook(IEnumerable<Book> data)
        {
            // PhysicalBook
            if (data is List<PhysicalBook> books)
            {
                string titleInput = "";
                string authorInput = "";
                float priceInput = 0;

                while (string.IsNullOrWhiteSpace(titleInput))
                {
                    Console.Write("""
                        Provide TITLE for the book: 
                        >> 
                        """);
                    titleInput = Console.ReadLine();
                }

                while (string.IsNullOrWhiteSpace(authorInput))
                {
                    Console.Write("""
                        Provide AUTHOR of the book: 
                        >> 
                        """);
                    authorInput = Console.ReadLine();
                }
                books.Add(new PhysicalBook(titleInput, authorInput));

                string rawPriceInput;
                Console.Write("""
                        Provide BORROW PRICE for the book: 
                        >> 
                        """);
                rawPriceInput = Console.ReadLine();

                while (!float.TryParse(rawPriceInput, out priceInput))
                {
                    Console.WriteLine("Invalid input. Please enter a number:");
                    rawPriceInput = Console.ReadLine();
                }
                
                books.FirstOrDefault(b => b.Title == titleInput).setPrice(titleInput, priceInput);

                Console.WriteLine("PhysicalBook '" + titleInput + "' has added sucesfully.");
            }

            // Ebook
            else if(data is List<Ebook> ebooks)
            {
                string titleInput = "";
                string authorInput = "";
                float priceInput = 0;

                string fileFormatInput = "";
                double fileSizeInput = 0;

                while (string.IsNullOrWhiteSpace(titleInput))
                {
                    Console.Write("""
                        Provide TITLE for the ebook: 
                        >> 
                        """);
                    titleInput = Console.ReadLine();
                }

                while (string.IsNullOrWhiteSpace(authorInput))
                {
                    Console.Write("""
                        Provide AUTHOR of the ebook: 
                        >> 
                        """);
                    authorInput = Console.ReadLine();
                }

                while (string.IsNullOrWhiteSpace(fileFormatInput))
                {
                    Console.Write("""
                        Provide FILE FORMAT for the ebook: 
                        >> 
                        """);
                    fileFormatInput = Console.ReadLine();
                }

                string rawFilseSizeInput;
                Console.Write("""
                        Provide FILE SIZE for the ebook: 
                        >> 
                        """);
                rawFilseSizeInput = Console.ReadLine();

                while (!double.TryParse(rawFilseSizeInput, out fileSizeInput))
                {
                    Console.WriteLine("Invalid input. Please enter a number:");
                    rawFilseSizeInput = Console.ReadLine();
                }

                ebooks.Add(new Ebook(titleInput, authorInput, fileFormatInput, fileSizeInput));


                string rawPriceInput;
                Console.Write("""
                        Provide BORROW PRICE for the ebook: 
                        >> 
                        """);
                rawPriceInput = Console.ReadLine();

                while (!float.TryParse(rawPriceInput, out priceInput))
                {
                    Console.WriteLine("Invalid input. Please enter a number:");
                    rawPriceInput = Console.ReadLine();
                }
                
                ebooks.FirstOrDefault(b => b.Title == titleInput).setPrice(titleInput, priceInput);

                Console.WriteLine("Ebook '" + titleInput + "' has added sucesfully.");
            }
        }

        // Edit PhysicalBook
        public static void EditBook(IEnumerable<Book> data)
        {
            if (data is List<PhysicalBook> books)
            {
                string userChoice = "";
                string titleInput = "";
                PhysicalBook book = null;

                while (book == null)
                {
                    Console.Write("""
                    What ebook do you want to edit (Provide a title): 
                    >> 
                    """);
                    titleInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(titleInput))
                    {
                        Console.WriteLine("Title cannot be empty. Please try again.");
                        continue;
                    }

                    book = books.Find(b => b.Title.ToLower() == titleInput.ToLower());

                    if (book == null)
                        Console.WriteLine("Book not found. Please enter an existing title.");
                }

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
                        string newTitle = "";

                        while (string.IsNullOrWhiteSpace(newTitle))
                        {
                            Console.Write("""
                            Provide new title
                            >> 
                            """);
                            newTitle = Console.ReadLine();
                        }
                        book.setTitle(newTitle);
                    }
                    else if (userChoice == "2" || userChoice.ToLower() == "author")
                    {
                        string newAuthor = "";

                        while (string.IsNullOrWhiteSpace(newAuthor))
                        {
                            Console.Write("""
                            Provide new author name
                            >> 
                            """);
                            newAuthor = Console.ReadLine();
                        }
                        book.setAuthor(newAuthor);
                    }
                    else if (userChoice == "3" || userChoice.ToLower() == "availability")
                    {
                        book.changeAvailability();
                    }
                    else if (userChoice == "4" || userChoice.ToLower() == "price")
                    {
                        float newPrice = 0;
                        string rawNewPrice;

                        Console.Write("""
                            Provide new price
                            >> 
                            """);
                        rawNewPrice = Console.ReadLine();

                        while (!float.TryParse(rawNewPrice, out newPrice))
                        {
                            Console.WriteLine("Invalid input. Please enter a number:");
                            rawNewPrice = Console.ReadLine();
                        }

                        book.setPrice(book.Title, newPrice);
                    }
                }
            }

            // Ebook
            else if(data is List<Ebook> ebooks)
            {
                string titleInput;
                string fileFormatInput;
                double fileSizeInput;
                string userChoice = "";
                Ebook ebook = null;

                while(ebook == null)
                {
                    Console.Write("""
                    What ebook do you want to edit (Provide a title): 
                    >> 
                    """);
                    titleInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(titleInput))
                    {
                        Console.WriteLine("Title cannot be empty. Please try again.");
                        continue;
                    }

                    ebook = ebooks.Find(b => b.Title.ToLower() == titleInput.ToLower());

                    if (ebook == null)
                        Console.WriteLine("Ebook not found. Please enter an existing title.");
                }

                while (userChoice != "6" && userChoice.ToLower() != "exit")
                {
                    Console.WriteLine("Ebook details:");
                    ebook.DisplayInfo();
                    Console.WriteLine("What do you want to change?");
                    Console.Write("""
                        Options:

                        1. Title
                        2. Author
                        3. Price
                        4. File format
                        5. File size
                        6. Exit

                        >> 
                        """);
                    userChoice = Console.ReadLine();
                    if (userChoice == "1" || userChoice.ToLower() == "title")
                    {
                        string newTitle = "";

                        while (string.IsNullOrWhiteSpace(newTitle))
                        {
                            Console.Write("""
                            Provide new title
                            >> 
                            """);
                            newTitle = Console.ReadLine();
                        }
                        ebook.setTitle(newTitle);
                    }
                    else if (userChoice == "2" || userChoice.ToLower() == "author")
                    {
                        string newAuthor = "";

                        while (string.IsNullOrWhiteSpace(newAuthor))
                        {
                            Console.Write("""
                            Provide new author name
                            >> 
                            """);
                            newAuthor = Console.ReadLine();
                        }
                        ebook.setAuthor(newAuthor);
                    }
                    else if (userChoice == "3" || userChoice.ToLower() == "price")
                    {
                        float newPrice = 0;
                        string rawNewPrice;

                        Console.Write("""
                            Provide new price
                            >> 
                            """);
                        rawNewPrice = Console.ReadLine();

                        while (!float.TryParse(rawNewPrice, out newPrice))
                        {
                            Console.WriteLine("Invalid input. Please enter a number:");
                            rawNewPrice = Console.ReadLine();
                        }
                        ebook.setPrice(ebook.Title, newPrice);
                    }
                    else if (userChoice == "4" || userChoice.ToLower() == "file format")
                    {
                        string newFileFormat = "";

                        while (string.IsNullOrWhiteSpace(newFileFormat))
                        {
                            Console.Write("""
                            Provide new file format
                            >> 
                            """);
                            newFileFormat = Console.ReadLine();
                        }
                        ebook.SetFileFormat(newFileFormat);
                    }
                    else if (userChoice == "5" || userChoice.ToLower() == "file size")
                    {
                        double newFileSize = 0;
                        string rawNewFileSize;

                        Console.Write("""
                            Provide new file size
                            >> 
                            """);
                        rawNewFileSize = Console.ReadLine();

                        while (!double.TryParse(rawNewFileSize, out newFileSize))
                        {
                            Console.WriteLine("Invalid input. Please enter a number:");
                            rawNewFileSize = Console.ReadLine();
                        }
                        ebook.SetFileSize(newFileSize);
                    }
                }
            }
        }

        // Delete PhysicalBook
        public static void DeleteBook(IEnumerable<Book> data)
        {
            // Book
            if (data is List<PhysicalBook> books)
            {
                string titleInput = "";
                PhysicalBook bookToRemove = null;

                while (bookToRemove == null)
                {
                    Console.Write(@"
                    What book do you want to remove (Provide a title): 
                    >> ");
                    titleInput = Console.ReadLine();

                    bookToRemove = books.Find(b => b.Title.ToLower() == titleInput.ToLower());

                    if (bookToRemove == null)
                        Console.WriteLine("Book not found. Please try again.");
                }

                books.Remove(bookToRemove);

                Console.WriteLine("The book has been removed from library.");
            }

            // Ebook
            else if (data is List<Ebook> ebooks)
            {
                string titleInput = "";
                Ebook ebookToRemove = null;

                while (ebookToRemove == null)
                {
                    Console.Write(@"
                    What ebook do you want to remove (Provide a title): 
                    >> ");
                    titleInput = Console.ReadLine();

                    ebookToRemove = ebooks.Find(e => e.Title.ToLower() == titleInput.ToLower());

                    if (ebookToRemove == null)
                        Console.WriteLine("Ebook not found. Please try again.");
                }

                ebooks.Remove(ebookToRemove);

                Console.WriteLine("The ebook has been removed from library.");
            }
        }
    }
}
