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
        private string _title;
        private string _author;
        private string _isbn;
        private int _publishedYear;
        private int _availableCopies;

        public string Title
        {
            get { return _title; }
            set { _title = value; } 
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string ISBN
        {
            get { return _isbn; }
            set { _isbn = value; }
        }

        public int PublishedYear
        {
            get { return _publishedYear; }
            set
            {
                if (value > 0) 
                    _publishedYear = value;
            }
        }

        public int AvailableCopies
        {
            get { return _availableCopies; }
            set
            {
                if (value >= 0)
                    _availableCopies = value;
            }
        }

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
                MessageBox.Show($"{Title} has been borrowed. Copies left: {AvailableCopies}");
            }
            else
            {
                MessageBox.Show($"{Title} is currently not available.");
            }
        }

        public void ReturnBook()
        {
            AvailableCopies++;
            MessageBox.Show($"{Title} has been returned. Copies now: {AvailableCopies}");
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
                MessageBox.Show($"Error serializing books data: {ex.Message}");
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
