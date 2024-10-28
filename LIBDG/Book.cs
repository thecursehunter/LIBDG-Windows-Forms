using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace LIBDG
{
    [Serializable]
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

        

        public void SerializeData(string FilePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(this);
                File.WriteAllText(FilePath, jsonData);
                Console.WriteLine($"Book data serialized to {FilePath}");   
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing book: {ex.Message}");
            }
        }

        public void DeserializeData(string FilePath)
        {
            try
            {
                string jsonData = File.ReadAllText(FilePath);
                Book deserializedBook = JsonSerializer.Deserialize<Book>(jsonData);

                if (deserializedBook != null)
                {
                    this.Title = deserializedBook.Title;
                    this.Author = deserializedBook.Author;
                    this.ISBN = deserializedBook.ISBN;
                    this.PublishedYear = deserializedBook.PublishedYear;
                    this.AvailableCopies = deserializedBook.AvailableCopies;
                }

                Console.WriteLine($"Book data deserialized from {FilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing book: {ex.Message}");
            }
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

        

        

        
    }
}
