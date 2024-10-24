using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; private set; }
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
                Console.WriteLine($"Transaction {TransactionID} completed: {Member.Name} borrowed {Book.Title}.");
            }
            else
            {
                Console.WriteLine($"The book {Book.Title} is not available.");
            }
        }

        
        public void CompleteReturn()
        {
            if (!IsReturned)
            {
                Member.ReturnBook(Book); 
                IsReturned = true;
                Console.WriteLine($"Transaction {TransactionID} completed: {Member.Name} returned {Book.Title}.");
            }
            else
            {
                Console.WriteLine($"This transaction has already been completed (book returned).");
            }
        }
        
        public bool IsOverdue()
        {
            if (!IsReturned && DateTime.Now > ReturnDate)
            {
                Console.WriteLine($"The book {Book.Title} is overdue.");
                return true;
            }
            return false;
        }

        public void ExtendBorrowing(int additionalDays)
        {
            if (!IsReturned)
            {
                ReturnDate = ReturnDate.AddDays( additionalDays );
                Console.WriteLine($"Borrowing period extended for {additionalDays} days. New return date: {ReturnDate.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine($"Cannot extend borrowing period. The book has already been returned.");
            }
        }
        
        public void DisplayTransactionInfo()
        {
            string status = IsReturned ? "Returned" : "Not Returned";
            Console.WriteLine($"Transaction ID: {TransactionID}");
            Console.WriteLine($"Member: {Member.Name}");
            Console.WriteLine($"Book: {Book.Title}");
            Console.WriteLine($"Borrow Date: {BorrowDate.ToShortDateString()}");
            Console.WriteLine($"Return Date: {ReturnDate.ToShortDateString()}");
            Console.WriteLine($"Status: {status}");
        }
    }
}
