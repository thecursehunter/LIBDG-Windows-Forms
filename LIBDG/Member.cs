using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace LIBDG
{
    public class Member : Person, IBorrowable, ISerializable
    {
        public int MemberID { get; set; }

        public Member() { }
        public Member(int memberId, string name, string email) : base(name, email)
        {
            MemberID = memberId;

        }

        public override void Login()
        {
            Console.WriteLine($"{Name} has logged in.");
        }

        public void SerializeData(string FilePath)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(this);
                File.WriteAllText(FilePath, jsonData);  // Ghi dữ liệu JSON ra file
                Console.WriteLine($"Member data serialized to {FilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error serializing member: {ex.Message}");
            }
        }

        public void DeserializeData(string FilePath) 
        {
            try
            {
                string jsonData = File.ReadAllText(FilePath);
                Member deserializedMember = JsonSerializer.Deserialize<Member>(jsonData);

                if (deserializedMember != null)
                {
                    this.Name = deserializedMember.Name;
                    this.Email = deserializedMember.Email;
                    this.MemberID = deserializedMember.MemberID;
                }

                Console.WriteLine($"Member data deserialized from {FilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing member: {ex.Message}");
            }
        }


        public void BorrowBook(Book book)      
        {
            book.BorrowBook();
            Console.WriteLine($"{Name} has borrowed the book: {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            book.ReturnBook();
            Console.WriteLine($"{Name} has returned the book: {book.Title}");
        }

    }
}
