using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
        //Lưu riêng danh sách books ra file json 
        public void SerializeData(string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(this);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("$\"Error serializing books data: {ex.Message}\"");
            }
        }
        //tải riêng danh sách books 
        public void DeserializeData(string FilePath)
        {
            string jsonData = File.ReadAllText(FilePath);
            Book deserializeBook = JsonSerializer.Deserialize<Book>(jsonData);

            if (deserializeBook != null)
            {
                this.Title = deserializeBook.Title; 
                this.Author = deserializeBook.Author;
                this.ISBN = deserializeBook.ISBN; 
                this.PublishedYear = deserializeBook.PublishedYear; 
                this.AvailableCopies = deserializeBook.AvailableCopies; 
            }



        }





    }
}
