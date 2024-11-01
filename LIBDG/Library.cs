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

        public Library()

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
                MessageBox.Show("This book has already existed in library");
            }
            else
            {
                Books.Add(newBook);
                MessageBox.Show("This book has added to library");
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
                MessageBox.Show($"Book '{removeBook.Title}' has been removed from the library.");
            }
            else
            {
                MessageBox.Show("Cannot find this book in the library.");
            }
        }

        public void UpdateBook(Book updatedBook)
        {
            bool bookFound = false;
            foreach (Book book in Books)
            {
                if (book.ISBN == updatedBook.ISBN)
                {
                    book.Title = updatedBook.Title;
                    book.Author = updatedBook.Author;
                    book.PublishedYear = updatedBook.PublishedYear;
                    book.AvailableCopies = updatedBook.AvailableCopies;
                    MessageBox.Show("This book has been updated");
                    bookFound = true;
                    break;
                }
            }
            if (!bookFound)
            {
                MessageBox.Show("Cannot find this book to update");
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




        
        public void RegisterMember(Member newMember)
        {
            bool memberExists = false;
            foreach (Member member in Members)
            {
                if (member.MemberID == newMember.MemberID)
                { 
                    memberExists = true;
                    break;
                }

                if (memberExists) 
                {
                    MessageBox.Show("This student has already existed in library");
                }

                else
                {
                    Members.Add(newMember);
                    MessageBox.Show("Added this student to library");
                }
            }

        }
        public void RemoveMember(int memberID)
        {
            Member memberToRemove = null;
            foreach (Member member in Members)
            {
                if (member.MemberID == memberID)
                {
                    memberToRemove = member;
                    break;
                }

                if (memberToRemove != null)
                {
                    Members.Remove(memberToRemove);
                    MessageBox.Show("Removed student from library");
                }

                else
                {
                    MessageBox.Show("Cannot find this student in library");
                }
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
        public List<Book> LoadBooksFromJsonAndFind(string filePath, string title)
        {
            List<Book> foundBooks = new List<Book>(); 

            
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return foundBooks; // Trả về danh sách rỗng nếu không tìm thấy file
            }

            try
            {
                // Đọc dữ liệu JSON từ file
                string jsonData = File.ReadAllText(filePath);

                // Deserialize dữ liệu JSON thành danh sách sách
                List<Book> loadedBooks = JsonSerializer.Deserialize<List<Book>>(jsonData);

                // Duyệt qua danh sách sách và thêm sách vào danh sách kết quả nếu khớp Title hoặc ISBN
                foreach (Book book in loadedBooks)
                {
                    if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        foundBooks.Add(book); 
                    }
                }

                
                return foundBooks;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing file: {ex.Message}");
                return foundBooks; 
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
                MessageBox.Show($"Error serializing library: {ex.Message}");
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

              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deserializing library: {ex.Message}");
            }
        }
        // lưu trữ riêng danh sách Books vào file JSON
        public void SerializeBooksData(string filePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(Books); 
                File.WriteAllText(filePath, jsonData);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error serializing books data: {ex.Message}");
            }
        }

        // load riêng danh sách Books từ file JSON
        public void DeserializeBooksData(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Book> deserializedBooks = JsonSerializer.Deserialize<List<Book>>(jsonData);

                if (deserializedBooks != null)
                {
                    this.Books = deserializedBooks; // Gán danh sách Books sau khi deserialization
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deserializing books data: {ex.Message}");
            }
        }

        // lưu danh sách Members 
        public void SerializeMembersData(string filePath) 
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(Members);
                File.WriteAllText(filePath, jsonData);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error serializing members data: {ex.Message}");
            }
        }
        // Tải danh sách Members
        public void DeserializeMembersData(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Member> deserializedMembers = JsonSerializer.Deserialize<List<Member>>(jsonData);

                if (deserializedMembers != null)
                {
                    this.Members = deserializedMembers;
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deserializing members data: {ex.Message}");
            }
        } 
        
        //lưu danh sách Transaction 
        public void SerializeTransactionsData(string filePath)
        {
            try
            { 
                string jsonData = JsonSerializer.Serialize(Transactions);
                File.WriteAllText (filePath, jsonData); 
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error serializing transactions data: {ex.Message}");
            }
        }
        //load danh sách transaction 
        public void DeserializeTransactionsData(string filePath)
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Transaction> deserializedTransactions = JsonSerializer.Deserialize<List<Transaction>>(jsonData);

                if (deserializedTransactions != null)
                {
                    this.Transactions = deserializedTransactions;
                }

             
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deserializing transactions data: {ex.Message}");
            }
        }

    }

}