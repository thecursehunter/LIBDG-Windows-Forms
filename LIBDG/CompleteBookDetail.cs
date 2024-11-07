using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class CompleteBookDetail : Form
    {
        public CompleteBookDetail()
        {
            InitializeComponent();
            InitializeDataGridView();  // Cấu hình các cột
            LoadTransactionData();     // Tải dữ liệu
        }

        private void InitializeDataGridView()
        {
            // Cấu hình cột cho dataGridViewBorrowedBooks
            dataGridViewBorrowedBooks.Columns.Clear();
            dataGridViewBorrowedBooks.Columns.Add("BookTitle", "Book Title");
            dataGridViewBorrowedBooks.Columns.Add("MemberName", "Member Name");
            dataGridViewBorrowedBooks.Columns.Add("BorrowDate", "Borrow Date");

            // Cấu hình cột cho dataGridViewReturnedBooks
            dataGridViewReturnedBooks.Columns.Clear();
            dataGridViewReturnedBooks.Columns.Add("BookTitle", "Book Title");
            dataGridViewReturnedBooks.Columns.Add("MemberName", "Member Name");
            dataGridViewReturnedBooks.Columns.Add("BorrowDate", "Borrow Date");
            dataGridViewReturnedBooks.Columns.Add("ReturnDate", "Return Date");
        }

        private void LoadTransactionData()
        {
            // Tải lại danh sách giao dịch từ file
            Library.Instance.Transactions.DeserializeData("transactions.json");



            dataGridViewBorrowedBooks.Rows.Clear();
            dataGridViewReturnedBooks.Rows.Clear();

            foreach (Transaction transaction in Library.Instance.Transactions.Transactions)
            {
                if (!transaction.IsReturned)
                {
                    dataGridViewBorrowedBooks.Rows.Add(
                        transaction.Book.Title,
                        transaction.Member.Name,
                        transaction.BorrowDate.ToShortDateString()
                    );
                }
                else
                {
                    dataGridViewReturnedBooks.Rows.Add(
                        transaction.Book.Title,
                        transaction.Member.Name,
                        transaction.BorrowDate.ToShortDateString(),
                        transaction.ReturnDate.ToShortDateString()
                    );
                }
            }
        }

    }
}
