﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class ViewBook : Form
    {

        public ViewBook()
        {
            InitializeComponent();
            dataGridViewBooks.CellClick += dataGridViewBooks_CellClick;
        }
        private void DisplayBooksInDataGridView(List<Book> books)
        {
            // Xóa các dòng hiện có trong DataGridView
            dataGridViewBooks.Rows.Clear();

            // Kiểm tra nếu DataGridView chưa có cột, thiết lập các cột
            if (dataGridViewBooks.Columns.Count == 0)
            {
                dataGridViewBooks.Columns.Add("Title", "Title");
                dataGridViewBooks.Columns.Add("Author", "Author");
                dataGridViewBooks.Columns.Add("ISBN", "ISBN");
                dataGridViewBooks.Columns.Add("PublishedYear", "Published Year");
                dataGridViewBooks.Columns.Add("AvailableCopies", "Available Copies");
            }

            // Thêm từng sách vào DataGridView
            foreach (Book book in books)
            {
                dataGridViewBooks.Rows.Add(book.Title, book.Author, book.ISBN, book.PublishedYear, book.AvailableCopies);
            }
        }
        private void dataGridViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow selectedRow = dataGridViewBooks.Rows[e.RowIndex];

                
                txtTitle.Text = selectedRow.Cells["Title"].Value.ToString();
                txtAuthor.Text = selectedRow.Cells["Author"].Value.ToString();
                txtISBN.Text = selectedRow.Cells["ISBN"].Value.ToString();
                txtPublishedYear.Text = selectedRow.Cells["PublishedYear"].Value.ToString();
                txtBookQuantity.Text = selectedRow.Cells["AvailableCopies"].Value.ToString();
            }
        }







        private void button3_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string isbn = txtISBN.Text;
            int publishedYear = int.Parse(txtPublishedYear.Text);
            int quantity = int.Parse(txtBookQuantity.Text);

            Book updatedBook = new Book(title, author, isbn, publishedYear, quantity);

            Library.Instance.Books.UpdateBook(updatedBook);

            Library.Instance.Books.SerializeData("books.json");
            MessageBox.Show("This book has been updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text;

            if (string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("Please enter ISBN to delete the book", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Library.Instance.Books.RemoveBook(isbn);

            Library.Instance.Books.SerializeData("books.json");
        }

        private void btnSearch_Click_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            string filePath = "books.json";
            List<Book> foundBooks = Library.Instance.Books.LoadBooksFromJsonAndFind(filePath, searchTerm);
            if (foundBooks.Count == 0)
            {
                MessageBox.Show("No book found with the provided information.");
                return;
            }

            DisplayBooksInDataGridView(foundBooks);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}