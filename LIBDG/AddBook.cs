using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string author = textBox2.Text;
            int publishYear = int.Parse(textBox3.Text);
            string isbn = textBox4.Text;
            int quantity = int.Parse(textBox5.Text);

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(isbn) || !int.TryParse(textBox3.Text, out publishYear) ||
                !int.TryParse(textBox5.Text, out quantity)
                )
            {
                MessageBox.Show("Please check book info again.");
                return;
            }
            Book newBook = new Book(title, author, isbn, publishYear, quantity);

            Library.Instance.AddBook(newBook);

            FileHandler fileHandler = new FileHandler();
            string booksFilePath = "books.json";
            fileHandler.SaveBooksData("books.json");
            MessageBox.Show("Books saved successfully!");



            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}