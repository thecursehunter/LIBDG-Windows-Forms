using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace LIBDG
{
    public class Library : ISerializable
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public List<Transaction> Transactions { get; set; }

        private static Library _instance;
        public static Library Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Library();
                }
                return _instance;
            }
        }
        private Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            Transactions = new List<Transaction>();
        }


        public void AddBook(Book newBook)
        {
            bool bookExists = false;

            foreach (Book book in Books)
            {
                if (book.ISBN == newBook.ISBN)
                {
                    bookExists = true;
                    break;
                }
            }

            if (bookExists)
            {
                MessageBox.Show("Sach nay da ton tai trong thu vien");
            }
            else
            {
                Books.Add(newBook);
                MessageBox.Show("Sach nay da duoc them vao thu vien");
            }
        }

        public void RemoveBook(string isbn)
        {
            Book removeBook = null;
            foreach (Book book in Books)
            {
                if (book.ISBN == isbn)
                {
                    removeBook = book;
                    break;
                }
            }

            if (removeBook != null)
            {
                Books.Remove(removeBook);
                MessageBox.Show($"Sach {removeBook.Title} da duoc xoa khoi thu vien");
            }
            else
            {
                MessageBox.Show("Khong tim thay sach nay trong thu vien");
            }
        }
        public Book FindBookByISBN(string isbn)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].ISBN == isbn)
                {
                    Console.WriteLine($"Found book: {Books[i].Title}");
                    return Books[i];
                }
            }
            Console.WriteLine("Book not found.");
            return null;

        }

        public void DisplayAllBook()
        {

        }
        public void RegisterMember(Member member)
        {
            bool memberExists = false;
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].MemberID == member.MemberID)
                {
                    memberExists = true;
                    break;
                }
            }
            if (!memberExists)
            {
                Members.Add(member);
            }
            else
            {
                Console.WriteLine($"Member with ID {member.MemberID} already exists.");
            }
        }

        public void RemoveMember(int memberID)
        {
            Member memberToRemove = null;
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].MemberID == memberID)
                {
                    memberToRemove = Members[i];
                    break;
                }
            }

            if (memberToRemove != null)
            {
                Members.Remove(memberToRemove);

            }
            else
            {
                Console.WriteLine($"Member with ID {memberID} not found.");
            }

        }
        public Member FindMemberByID(int memberID)
        {
            for (int i = 0; i < Members.Count; i++)
            {
                if (Members[i].MemberID == memberID)
                {
                    return Members[i];
                }
            }
            Console.WriteLine("Member not found");
            return null;
        }



        public void DisplayAllMember()
        {

        }
        public void BorrowBook(int memberID, string isbn)
        {
            Member member = FindMemberByID(memberID);
            Book book = FindBookByISBN(isbn);
            if (member != null && book != null && book.AvailableCopies > 0)
            {
                Transaction transaction = new Transaction(Transactions.Count + 1, member, book, DateTime.Now, DateTime.Now.AddDays(14));
                transaction.CompleteBorrowing();
                Transactions.Add(transaction);
                Console.WriteLine($"Transaction {transaction.TransactionID} created for {member.Name} to borrow {book.Title}.");
            }
            else
            {
                Console.WriteLine("Cannot complete borrowing. Book might be unavailable or member not found.");
            }

        }
        public void ReturnBook(int memberID, string isbn)
        {
            //biến để lưu giao dịch trả sách nếu tìm thấy 
            Transaction transactiontoReturn = null;

            // Tìm giao dịch với memberid và isbn khớp 
            for (int i = 0; i < Transactions.Count; i++)
            {
                if (Transactions[i].Member.MemberID == memberID &&
                    Transactions[i].Book.ISBN == isbn &&
                                                !Transactions[i].IsReturned)
                {
                    transactiontoReturn = Transactions[i];
                    break; 
                }

            }

            if (transactiontoReturn != null)
            {
                transactiontoReturn.CompleteReturn();
                Console.WriteLine($"Transaction {transactiontoReturn.TransactionID} completed: {transactiontoReturn.Member.Name} returned {transactiontoReturn.Book.Title}.");
            }
            else
            {
                Console.WriteLine($"No matching transaction found for Member ID {memberID} and ISBN {isbn}.");
            } 


        }
      

        public void SerializeData(string FilePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(this);
                File.WriteAllText(FilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing library: {ex.Message}");
            }
        }

        public void DeserializeData(string FilePath)
        {
            try
            {
                string jsonData = File.ReadAllText(FilePath);
                Library deserializedLibrary = JsonSerializer.Deserialize<Library>(jsonData);

                if (deserializedLibrary != null)
                {
                    this.Books = deserializedLibrary.Books;
                    this.Members = deserializedLibrary.Members;
                    this.Transactions = deserializedLibrary.Transactions;
                }

                Console.WriteLine($"Library data deserialized from {FilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing library: {ex.Message}");
            }
        }
    }

}