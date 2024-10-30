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
            Library library = new Library(); 
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
            string searchTerm = txtSearch.Text;
            string filePath = "book.json";
            List<Book> foundBooks = Library.LoadBooksFromJsonAndFind(filePath, searchTerm);

            DisplayBooksInDataGridView(foundBooks);
        }
    }
}
