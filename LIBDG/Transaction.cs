using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDG
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public Transaction(int transactionId, Member member, Book book, DateTime borrowDate, DateTime returnDate)
        {
            TransactionID = transactionId;
            Member = member;
            Book = book;
            BorrowDate = borrowDate;
            ReturnDate = returnDate;
            IsReturned = false;
        }

        public void CompleteBorrowing()
        {
            if (Book.AvailableCopies > 0)
            {
                Member.BorrowBook(Book);
                MessageBox.Show($"Transaction {TransactionID} completed: {Member.Name} borrowed {Book.Title}.");
            }
            else
            {
                MessageBox.Show($"The book {Book.Title} is not available.");
            }
        }


        public void CompleteReturn()
        {
            if (!IsReturned)
            {
                Member.ReturnBook(Book);
                IsReturned = true;
                
            }
            else
            {
                MessageBox.Show($"This transaction has already been completed (book returned).");
            }
        }


    }
}
