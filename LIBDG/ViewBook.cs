using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class ViewBook : Form
    {
      
        public ViewBook()
        {
            InitializeComponent();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            string filePath = "books.json";
            List<Book> foundBooks = Library.Instance.LoadBooksFromJsonAndFind(filePath, searchTerm);

            DisplayBooksInDataGridView(foundBooks);
        }
    }
}
