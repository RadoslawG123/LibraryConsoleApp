using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class PhysicalBook: Book
    {
        public bool Available { get; private set; }

        public PhysicalBook(string title, string author) : base(title, author)
        {
            Available = true;
        }

        public override void DisplayInfo()
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

        public void changeAvailability()
        {
            Available = !Available;
            Console.WriteLine($"Availability is changed from {!Available} to {Available}");
        }
    }
}
