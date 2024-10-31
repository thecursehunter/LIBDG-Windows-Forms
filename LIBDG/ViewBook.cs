using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class ViewBook : Form
    {
        private Library library; 
        public ViewBook()
        {
            InitializeComponent();
        }
        private void DisplayBooksInDataGridView(List<Book> books)
        {
            // Xóa các dòng hiện có trong DataGridView
            dataGridViewBooks.Rows.Clear();

            // Thêm từng sách vào DataGridView
            foreach (Book book in books)
            {
                dataGridViewBooks.Rows.Add(book.Title, book.Author, book.ISBN, book.PublishedYear, book.AvailableCopies);
            } 

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string author = txtAuthor.Text;
            string isbn = txtISBN.Text;
            int publishedYear = int.Parse(txtPublishedYear.Text);
            int quantity = int.Parse(txtBookQuantity.Text);

            Book updatedBook = new Book(title, author, isbn, publishedYear, quantity);

            Library.Instance.UpdateBook(updatedBook, "library.json");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text;

            if (string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("Please enter ISBN to delete book", "Noti", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Library.Instance.RemoveBook(isbn, "library.json");
        }
    }
}
