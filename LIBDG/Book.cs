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
        
        public Book(string tilte, string author, string  isbn, int publishedYear, int availableCopies)
        {
            Title = tilte;  
            Author = author;
            ISBN = isbn; 
            PublishedYear = publishedYear;
            AvailableCopies = availableCopies; 
        }
        public void BorrowBook()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                Console.WriteLine($"{Title} đã được mượn, số lượng còn lại {AvailableCopies}");
            }
            else 
            {
                Console.WriteLine($"{Title} hiện đang hết. ");
            } 
            
        } 
        public void ReturnBook()
        {
            AvailableCopies++;
            Console.WriteLine($"{Title} đã được trả, số lượng còn lại {AvailableCopies}");
        }

        public void SerializeData()
        {
            Console.WriteLine($"Serializing Book {Title}.");
        }

        public void DeserializeData()
        {
            Console.WriteLine($"Deserializing Book {Title}.");
        }
    }

}
