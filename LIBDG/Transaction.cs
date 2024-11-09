using System;
using System.Windows.Forms;

namespace LIBDG
{
    public class Transaction
    {
        private int _transactionID;
        private Member _member;
        private Book _book;
        private DateTime _borrowDate;
        private DateTime _returnDate;
        private bool _isReturned;

        public int TransactionID
        {
            get { return _transactionID; }
            set { _transactionID = value; }
        }

        public Member Member
        {
            get { return _member; }
            set { _member = value; } 
        }

        public Book Book
        {
            get { return _book; }
            set { _book = value; } 
        }

        public DateTime BorrowDate
        {
            get { return _borrowDate; }
            set { _borrowDate = value; }
        }

        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set { _returnDate = value; } 
        }

        public bool IsReturned
        {
            get { return _isReturned; }
            set { _isReturned = value; } 
        }

        public Transaction() { }
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
