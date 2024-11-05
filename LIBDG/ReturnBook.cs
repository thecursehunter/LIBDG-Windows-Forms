using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
            textBoxBorrowDate.ReadOnly = true;
            dataGridViewTransactions.CellClick += dataGridViewTransactions_CellClick;
            textBoxBookTitle.ReadOnly = true;

        }

        private void buttonSearchStudents_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxSearchStudentID.Text.Trim(), out int memberID))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            // **Tải lại danh sách giao dịch từ file JSON**
            Library.Instance.DeserializeTransactionsData("transactions.json");

            List<Transaction> memberTransactions = Library.Instance.Transactions
                .Where(transaction => transaction.Member.MemberID == memberID && !transaction.IsReturned)
                .ToList();

            if (memberTransactions.Count == 0)
            {
                MessageBox.Show("No borrowed books found for this member.");
                return;
            }

            DisplayTransactionsInDataGridView(memberTransactions);
        }





        private void DisplayTransactionsInDataGridView(List<Transaction> transactions)
        {
            dataGridViewTransactions.Rows.Clear();

            if (dataGridViewTransactions.Columns.Count == 0)
            {
                dataGridViewTransactions.Columns.Add("BookTitle", "Book Title");
                dataGridViewTransactions.Columns.Add("BorrowDate", "Borrow Date");
                dataGridViewTransactions.Columns.Add("ReturnDate", "Return Date");
            }

            foreach (Transaction transaction in transactions)
            {
                if (!transaction.IsReturned)
                {
                    dataGridViewTransactions.Rows.Add(transaction.Book.Title, transaction.BorrowDate.ToShortDateString(), transaction.ReturnDate.ToShortDateString());
                }
            }
        }


        private void dataGridViewTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) //chắc chắn rằng click vô dòng data chứ ko phải tựa đề hay khoảng trắng trong datagrid  
            {
                DataGridViewRow selectedRow = dataGridViewTransactions.Rows[e.RowIndex];

                string bookTitle = selectedRow.Cells["BookTitle"].Value.ToString();
                DateTime borrowDate = DateTime.Parse(selectedRow.Cells["BorrowDate"].Value.ToString());
                DateTime returnDate = DateTime.Parse(selectedRow.Cells["ReturnDate"].Value.ToString());

                // Hiển thị thông tin vào các TextBox hoặc DateTimePicker
                textBoxBookTitle.Text = bookTitle;
                textBoxBorrowDate.Text = borrowDate.ToShortDateString(); // Hiển thị ngày mượn, không cho chỉnh sửa
                dateTimePickerReturnDate.Value = returnDate;

            }

        }
        private void LoadBorrowedBooksForMember(int memberID)
        {
            dataGridViewTransactions.Rows.Clear();

            

            foreach (Transaction transaction in Library.Instance.Transactions)
            {
                if (transaction.Member.MemberID == memberID && !transaction.IsReturned)
                {
                    dataGridViewTransactions.Rows.Add(transaction.Book.Title, transaction.BorrowDate.ToShortDateString(), transaction.ReturnDate.ToShortDateString());
                }
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchStudentID.Text))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            if (!int.TryParse(textBoxSearchStudentID.Text, out int studentID))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            string selectedBookTitle = textBoxBookTitle.Text;
            DateTime updatedReturnDate = dateTimePickerReturnDate.Value;

            Transaction transactionToReturn = null;
            foreach (Transaction transaction in Library.Instance.Transactions)
            {
                if (transaction.Member.MemberID == studentID &&
                    transaction.Book.Title.Equals(selectedBookTitle, StringComparison.OrdinalIgnoreCase) &&
                    !transaction.IsReturned)
                {
                    transactionToReturn = transaction;
                    break;
                }
            }

            if (transactionToReturn != null)
            {
                if (updatedReturnDate < transactionToReturn.BorrowDate)
                {
                    MessageBox.Show("Return date cannot be before the borrow date.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                transactionToReturn.ReturnDate = updatedReturnDate;
                transactionToReturn.CompleteReturn();

                MessageBox.Show("Book returned successfully!");

                // **Lưu danh sách giao dịch ngay sau khi cập nhật `IsReturned`**
                Library.Instance.SerializeTransactionsData("transactions.json");
                

                // Làm mới lại `DataGridView` để chỉ hiển thị các giao dịch chưa trả
                LoadBorrowedBooksForMember(studentID);
                
                
            }
            else
            {
                MessageBox.Show($"No matching transaction found for Student ID: {studentID} and Book Title: {selectedBookTitle}. Make sure the transaction is not marked as returned.");
            }
        }



    }



}





