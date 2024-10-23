using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Book : ISerializable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int AvailableCopies { get; set; }

        public Book() { }

        public Book(string title, string author, string isbn, int year, int copies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedYear = year;
            AvailableCopies = copies;
        }

        public void BorrowBook()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                Console.WriteLine($"{Title} has been borrowed. Copies left: {AvailableCopies}");
            }
            else
            {
                Console.WriteLine($"{Title} is currently not available.");
            }
        }

        public void ReturnBook()
        {
            AvailableCopies++;
            Console.WriteLine($"{Title} has been returned. Copies now: {AvailableCopies}");
        }

        public void SerializeData()
        {
            Console.WriteLine($"Serializing book: {Title}");
            // Logic for serializing Book object
        }

        public void DeserializeData()
        {
            Console.WriteLine($"Deserializing book: {Title}");
            // Logic for deserializing Book object
        }
    }
}
