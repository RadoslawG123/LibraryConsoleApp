using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("""
                
                Welcome to the library!

                Options:
                1. Show all Books
                2. Add new Book
                3. Delete Book
                4. Borrow Book
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

                if (input == 1)
                {
                    Console.WriteLine("""
                        All books in the library:

                        """);
                    foreach(Book book in Books)
                    {

                    }
                }
                if(input == 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
    }
}
