using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryConsoleApp
{
    public class Ebook : Book
    {
        public string FileFormat { get; private set; }
        public double FileSize { get; private set; }

        public Ebook(string title, string author, string fileFormat, double fileSize):base(title, author)
        {
            FileFormat = fileFormat;
            FileSize = fileSize;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Author: " + Author);
            Console.WriteLine("File format: " + FileFormat);
            Console.WriteLine("File size: " + FileSize + "MB");
            Console.WriteLine("Price: " + Price + "$");
            Console.WriteLine("--------------------------------------------------------------");
        }

        public void SetFileFormat(string format)
        {
            List<string> allowedFormats = new List<string> { "PDF", "EPUB", "MOBI", "TXT", "MP3", "MP4" };

            if (format.Length == 0)
            {
                Console.WriteLine("File format can't be empty. Please try again.");
                return;
            }
            else if(!allowedFormats.Contains(format))
            {
                Console.WriteLine("Invalid file format. Please check allowed file formats.");
                Console.WriteLine("Allowed file formats: ");
                foreach(string allowedFormat in allowedFormats)
                {
                    Console.WriteLine("- " + allowedFormat);
                }
                return;
            }

            FileFormat = format.ToUpper();
            Console.WriteLine($"File format {format} is setted succesfully.");
        }

        public void SetFileSize(double size)
        {
            if (size < 0.1)
            {
                Console.WriteLine($"File size is too small (min 0.1MB). Please try again.");
                return;
            }
            else if(size > 500)
            {
                Console.WriteLine($"File size is too big (max 500MB). Please try again.");
                return;
            }

            FileSize = size;
            Console.WriteLine($"File format {size} is setted succesfully.");
        }

    }
}
