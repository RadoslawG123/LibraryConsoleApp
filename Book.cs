using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class Book
    {
        public string Title { get; set; }
        public bool Available { get; set; }
        public decimal Price { get; private set; }

        public Book(string title) 
        {
            Title = title;
            Price = 0;

            Available = true;
        }

        private string setPrice(string title, decimal price) 
        {
            decimal newPrice;
            if (price < 0)
                return "Price shouldn't be lower than 0$. Please try again.";

            return "Price is setted successfully for '" + title + "'";
        }
    }
}
