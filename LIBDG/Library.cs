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
            this.Books = DeserializeBooksData("books.json");
            this.Members = DeserializeMembersData("members.json");
            this.Transactions = DeserializeTransactionsData("transactions.json");
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
        public Book FindBookByTitle(string title)
        {

            foreach (Book book in Books)
            {

                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }


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

        public void UpdateMemberInfo(Member updatedMember)
        {
            bool memberFound = false;
            foreach (Member member in Members)
            {
                if (member.MemberID == updatedMember.MemberID)
                {
                    member.Name = updatedMember.Name;
                    member.Email = updatedMember.Email;

                    memberFound = true;
                    break;
                }
            }

            if (!memberFound)
            {
                MessageBox.Show("Cannot find this member to update");
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
                // Serialize lại danh sách Books hiện tại trong Library.Instance
                string jsonData = JsonSerializer.Serialize(this.Books);
                File.WriteAllText(filePath, jsonData); // Ghi đè nội dung cũ trong file
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error serializing books data: {ex.Message}");
            }
        }




        // load riêng danh sách Books từ file JSON
        public List<Book> DeserializeBooksData(string filePath)
        {
            try
            {


                string jsonData = File.ReadAllText(filePath);



                return JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new List<Book>();
            }
            catch (JsonException)
            {

                return new List<Book>();
            }
            catch (Exception)
            {

                return new List<Book>();
            }
        }



        // lưu danh sách Members 
        public void SerializeMembersData(string filePath)
        {
            try
            {
                // Ghi đè toàn bộ danh sách Members hiện tại
                string jsonData = JsonSerializer.Serialize(this.Members);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception)
            {

            }
        }


        // Tải danh sách Members
        public List<Member> DeserializeMembersData(string filePath)
        {
            try
            {


                string jsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Member>>(jsonData) ?? new List<Member>();
            }
            catch (Exception)
            {

                return new List<Member>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }

        public List<Member> LoadMembersFromJsonAndFind(string filePath, string searchTerm)
        {
            List<Member> foundMembers = new List<Member>();


            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return foundMembers;
            }

            try
            {

                string jsonData = File.ReadAllText(filePath);


                List<Member> loadedMembers = JsonSerializer.Deserialize<List<Member>>(jsonData);

                foreach (Member member in loadedMembers)
                {
                    if (member.MemberID.ToString().Equals(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                        member.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                    {
                        foundMembers.Add(member);
                    }
                }

                return foundMembers;
            }
            catch (Exception ex)
            {

                return foundMembers;
            }
        }
        



        //lưu danh sách Transaction 
        public void SerializeTransactionsData(string filePath)
        {
            try
            {
                // Serialize danh sách giao dịch hiện tại trong Library.Instance.Transactions và ghi đè file
                string jsonData = JsonSerializer.Serialize(this.Transactions);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception)
            {

            }
        }


        //load danh sách transaction 
        public List<Transaction> DeserializeTransactionsData(string filePath)
        {
            try
            {


                string jsonData = File.ReadAllText(filePath);



                return JsonSerializer.Deserialize<List<Transaction>>(jsonData) ?? new List<Transaction>();
            }
            catch (JsonException)
            {

                return new List<Transaction>();
            }
            catch (Exception)
            {

                return new List<Transaction>();
            }
        }


        public List<Transaction> LoadTransactionsForMember(string filePath, int memberID)
        {
            List<Transaction> transactions = new List<Transaction>();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found.");
                return transactions;
            }

            try
            {
                string jsonData = File.ReadAllText(filePath);
                List<Transaction> loadedTransactions = JsonSerializer.Deserialize<List<Transaction>>(jsonData) ?? new List<Transaction>();

                // Chỉ thêm các giao dịch chưa trả
                foreach (Transaction transaction in loadedTransactions)
                {
                    if (transaction.Member.MemberID == memberID && !transaction.IsReturned)
                    {
                        transactions.Add(transaction);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading or parsing file: {ex.Message}");
            }

            return transactions;
        }



    }

}