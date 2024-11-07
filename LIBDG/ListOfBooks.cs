using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace LIBDG
{
    public class ListOfBooks : ISerializable
    {
        public List<Book> Books { get; set; }

        public ListOfBooks()
        {
            Books = new List<Book>();
        }
        public void AddBook(Book newBook)
        {
            bool bookExists = false;
            foreach (Book book in Books)
            {
                if (book.ISBN == newBook.ISBN)
                {
                    bookExists = true;
                    break;
                }
            }

            if (bookExists)
            {
                MessageBox.Show("This book already exists in the library.");
            }
            else
            {
                Books.Add(newBook);
                MessageBox.Show("Added this book to the library.");
            }
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = null;
            foreach (Book book in Books)
            {
                if (book.ISBN == isbn)
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                Books.Remove(bookToRemove);
                MessageBox.Show($"Book '{bookToRemove.Title}' has been removed from the library.");
            }
            else
            {
                MessageBox.Show("Cannot find this book in the library.");
            }
        }

        public void UpdateBook(Book updatedBook)
        {
            bool bookFound = false;
            foreach (Book book in Books)
            {
                if (book.ISBN == updatedBook.ISBN)
                {
                    book.Title = updatedBook.Title;
                    book.Author = updatedBook.Author;
                    book.PublishedYear = updatedBook.PublishedYear;
                    book.AvailableCopies = updatedBook.AvailableCopies;
                    bookFound = true;
                    break;
                }
            }

            if (!bookFound)
            {
                MessageBox.Show("Cannot find this book to update.");
            }
        }
        public Book FindBookByTitle(string title)
        {
            foreach (Book book in Books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> LoadBooksFromJsonAndFind(string filePath, string title)
        {
            List<Book> foundBooks = new List<Book>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return foundBooks;
            }

            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Book> loadedBooks = JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new List<Book>();

                foreach (Book book in loadedBooks)
                {
                    if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        foundBooks.Add(book);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing file: {ex.Message}");
            }

            return foundBooks;
        }

        public void SerializeData(string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(Books);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error serializing books data: {ex.Message}");
            }
        }

        public void DeserializeData(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    Books = JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new List<Book>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deserializing books data: {ex.Message}");
            }
        }
    }
}
