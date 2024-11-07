using System;
using System.Collections.Generic;
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

            // Sử dụng phương thức từ ListOfMembers để tìm thành viên
            List<Member> foundMembers = Library.Instance.Members.LoadMembersFromJsonAndFind("members.json", memberID.ToString());

            if (foundMembers.Count == 0)
            {
                MessageBox.Show("No member found with the provided Student ID.");
                return;
            }

            // Giả định rằng ID là duy nhất, chỉ lấy thành viên đầu tiên trong danh sách
            Member member = foundMembers[0];

            textBoxStudentName.Text = member.Name;
            textBoxStudentID.Text = member.MemberID.ToString();
            textBoxStudentEmail.Text = member.Email;
        }

        private void IssueBookForm_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu sách và cập nhật combobox từ ListOfBooks
            Library.Instance.Books.DeserializeData("books.json");

            comboBoxBookTitles.Items.Clear();
            foreach (Book book in Library.Instance.Books.Books)
            {
                comboBoxBookTitles.Items.Add(book.Title);
            }

            if (comboBoxBookTitles.Items.Count > 0)
            {
                comboBoxBookTitles.SelectedIndex = 0;
            }

            // Tải danh sách thành viên từ ListOfMembers
            Library.Instance.Members.DeserializeData("members.json");
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

            // Tìm đối tượng Member từ ListOfMembers
            Member member = Library.Instance.Members.FindMemberByID(studentID);
            if (member == null)
            {
                MessageBox.Show("Member not found in the library.");
                return;
            }

            int borrowedBooksCount = 0;
            foreach (Transaction currenttransaction in Library.Instance.Transactions.Transactions)
            {
                if (currenttransaction.Member.MemberID == studentID && !currenttransaction.IsReturned)
                {
                    borrowedBooksCount++;
                    if (currenttransaction.Book.Title.Equals(selectedBookTitle, StringComparison.OrdinalIgnoreCase))
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

            // Tìm đối tượng Book từ ListOfBooks
            Book book = Library.Instance.Books.FindBookByTitle(selectedBookTitle);
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

            // Tạo Transaction mới và thêm vào ListOfTransactions
            Transaction transaction = new Transaction(
                transactionId: Library.Instance.Transactions.Transactions.Count + 1,
                member: member,
                book: book,
                borrowDate: borrowDate,
                returnDate: returnDate
            );

            // Cập nhật trạng thái mượn sách và lưu lại
            transaction.CompleteBorrowing();
            Library.Instance.Transactions.Transactions.Add(transaction);

            Library.Instance.Transactions.SerializeData("transactions.json");

            // Xóa thông tin trên form sau khi hoàn thành
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
