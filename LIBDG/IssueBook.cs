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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
            this.Load += IssueBookForm_Load;
        }

        private void buttonSearchStudents_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(textBoxSearchStudentID.Text.Trim(), out int memberID))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            string membersFilePath = "members.json";
            List<Member> foundMembers = Library.Instance.LoadMembersFromJsonAndFind(membersFilePath, memberID.ToString());

            if (foundMembers.Count == 0)
            {
                MessageBox.Show("No member found with the provided Student ID.");
                return;
            }

            //vì mã ID chỉ có 1 nên search ra thì lấy thằng đầu tiên trong mảng
            Member member = foundMembers[0];


            textBoxStudentName.Text = member.Name;
            textBoxStudentID.Text = member.MemberID.ToString();
            textBoxStudentEmail.Text = member.Email;


        }
        private void IssueBookForm_Load(object sender, EventArgs e)
        {

            string booksFilePath = "books.json";
            List<Book> books = Library.Instance.DeserializeBooksData(booksFilePath);

            Library.Instance.Books = books;

            comboBoxBookTitles.Items.Clear();

            foreach (Book book in books)
            {
                comboBoxBookTitles.Items.Add(book.Title);
            }
            // nếu có giá trị thì tự động chọn mục đầu tiên 
            if (comboBoxBookTitles.Items.Count > 0)
            {
                comboBoxBookTitles.SelectedIndex = 0;
            }

            string membersFilePath = "members.json";
            List<Member> members = Library.Instance.DeserializeMembersData(membersFilePath);

            // Gán danh sách members vào Library.Instance.Members
            Library.Instance.Members = members;
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxStudentName.Text) ||
                string.IsNullOrWhiteSpace(textBoxStudentID.Text) ||
                string.IsNullOrWhiteSpace(textBoxStudentEmail.Text) ||
                comboBoxBookTitles.SelectedItem == null)
            {
                MessageBox.Show("Please ensure all fields are filled out.");
                return;
            }

            if (!int.TryParse(textBoxStudentID.Text, out int studentID))
            {
                MessageBox.Show("Invalid Student ID format.");
                return;
            }

            string selectedBookTitle = comboBoxBookTitles.SelectedItem.ToString();
            DateTime borrowDate = dateTimePickerIssueDate.Value;
            DateTime returnDate = borrowDate.AddDays(14);

            // Tìm đối tượng Member dựa trên Student ID
            Member member = Library.Instance.FindMemberByID(studentID);
            if (member == null)
            {
                MessageBox.Show("Member not found in the library.");
                return;
            }

            int borrowedBooksCount = 0;
            foreach (Transaction transaction1 in Library.Instance.Transactions)
            {
                if (transaction1.Member.MemberID == studentID && !transaction1.IsReturned)
                {
                    borrowedBooksCount++;
                    //kiểm sách trùng 
                    if (transaction1.Book.Title.Equals(selectedBookTitle, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("This book has already been borrowed by the member.");
                        return;
                    }
                }
            }
            if (borrowedBooksCount >= 3)
            {
                MessageBox.Show("A member can borrow up to 3 books only.");
                return;
            }


            Book book = Library.Instance.FindBookByTitle(selectedBookTitle);
            if (book == null)
            {
                MessageBox.Show("Book not found in the library.");
                return;
            }


            if (book.AvailableCopies <= 0)
            {
                MessageBox.Show("No available copies of this book.");
                return;
            }



            // Tạo Transaction mới cho việc mượn sách
            Transaction transaction = new Transaction(
                transactionId: Library.Instance.Transactions.Count + 1,
                member: member,
                book: book,
                borrowDate: borrowDate,
                returnDate: returnDate
            );

            // Hoàn thành việc mượn sách (giảm số lượng sách có sẵn)
            transaction.CompleteBorrowing();



            Library.Instance.Transactions.Add(transaction);

            FileHandler fileHandler = new FileHandler();
            string transactionFilePath = "transactions.json";
            fileHandler.SaveTransactionsData(transactionFilePath);



            textBoxStudentID.Clear();
            textBoxStudentName.Clear();
            textBoxStudentEmail.Clear();
            comboBoxBookTitles.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxStudentID.Clear();
            textBoxStudentName.Clear();
            textBoxStudentEmail.Clear();
        }
    }
}