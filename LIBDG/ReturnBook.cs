using System;
using System.Collections.Generic;
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
          
            dataGridViewTransactions.Rows.Clear();
            if (!int.TryParse(textBoxSearchStudentID.Text.Trim(), out int memberID))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }


            // Tải lại danh sách giao dịch từ file JSON để có dữ liệu mới nhất
            
            Library.Instance.Transactions.DeserializeData("transactions.json");
            List<Transaction> unreturnedTransactions = Library.Instance.Transactions.GetUnreturnedTransactionsForMember(memberID);

            if (unreturnedTransactions.Count == 0)
            {
                MessageBox.Show("No borrowed books found for this member.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DisplayTransactionsInDataGridView(unreturnedTransactions);
        }

        private void LoadBorrowedBooksForMember(int memberID)
        {
            // Xóa tất cả hàng trong DataGridView trước khi thêm dữ liệu mới
            dataGridViewTransactions.Rows.Clear();


            // Kiểm tra và tạo các cột nếu chưa có
            if (dataGridViewTransactions.Columns.Count == 0)
            {
                dataGridViewTransactions.Columns.Add("BookTitle", "Book Title");
                dataGridViewTransactions.Columns.Add("BorrowDate", "Borrow Date");
                dataGridViewTransactions.Columns.Add("ReturnDate", "Return Date");
            }

            bool hasBorrowedBooks = false;

            List<Transaction> unreturnedTransactions = Library.Instance.Transactions.GetUnreturnedTransactionsForMember(memberID);
            foreach (Transaction transaction in unreturnedTransactions)
            {
                dataGridViewTransactions.Rows.Add(
                    transaction.Book.Title,
                    transaction.BorrowDate.ToShortDateString(),
                    transaction.ReturnDate.ToShortDateString() ?? "Not Returned"
                );
                hasBorrowedBooks = true;
            }
            if (!hasBorrowedBooks)
            {
                MessageBox.Show("No borrowed books found for this member.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearchStudentID.Text))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }
            int studentID;
            if (!int.TryParse(textBoxSearchStudentID.Text, out studentID))
            {
                MessageBox.Show("Please enter a valid Student ID.");
                return;
            }

            string selectedBookTitle = textBoxBookTitle.Text;
            DateTime updatedReturnDate = dateTimePickerReturnDate.Value;

            Transaction transactionToReturn = null;
            foreach (Transaction transaction in Library.Instance.Transactions.Transactions)
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


                // Lưu danh sách giao dịch ngay sau khi cập nhật `IsReturned`
                Library.Instance.Transactions.SerializeData("transactions.json");



                // Làm mới lại `DataGridView` để chỉ hiển thị các giao dịch chưa trả
                LoadBorrowedBooksForMember(studentID);

            }
            else
            {
                MessageBox.Show($"No matching transaction found for Student ID: {studentID} and Book Title: {selectedBookTitle}. Make sure the transaction is not marked as returned.");
            }
        }
        private void DisplayTransactionsInDataGridView(List<Transaction> transactions)
        {
            // Xóa tất cả các hàng hiện có trong DataGridView trước khi thêm dữ liệu mới
            dataGridViewTransactions.Rows.Clear();

            // Kiểm tra và thêm các cột nếu chưa tồn tại
            if (dataGridViewTransactions.Columns.Count == 0)
            {
                dataGridViewTransactions.Columns.Add("BookTitle", "Book Title");
                dataGridViewTransactions.Columns.Add("BorrowDate", "Borrow Date");
                dataGridViewTransactions.Columns.Add("ReturnDate", "Return Date");
            }

            // Duyệt qua danh sách giao dịch và thêm từng giao dịch vào DataGridView
            foreach (Transaction transaction in transactions)
            {
                // Chỉ thêm các giao dịch chưa trả (IsReturned = false)
                if (!transaction.IsReturned)
                {
                    dataGridViewTransactions.Rows.Add(
                        transaction.Book.Title,
                        transaction.BorrowDate.ToShortDateString(),
                        transaction.ReturnDate.ToShortDateString()
                    );
                }
            }

            // Kiểm tra nếu không có giao dịch nào được thêm vào DataGridView
            if (dataGridViewTransactions.Rows.Count == 0)
            {
                MessageBox.Show("No borrowed books found for this member.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewTransactions.Rows[e.RowIndex];
                textBoxBookTitle.Text = selectedRow.Cells["BookTitle"].Value.ToString();
                textBoxBorrowDate.Text = selectedRow.Cells["BorrowDate"].Value.ToString();
                dateTimePickerReturnDate.Value = DateTime.Parse(selectedRow.Cells["ReturnDate"].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxBookTitle.Clear();
            textBoxBorrowDate.Clear();
            dateTimePickerReturnDate.Refresh();
            dataGridViewTransactions.Rows.Clear();
        }
    }
}
