using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Member : Person, IBorrowable, ISerializable
    {
        public int MemberID { get; set; }

        public Member(int memberId, string name, string email) : base(name, email)
        {
            MemberID = memberId;
        }

        public override void Login()
        {
            Console.WriteLine($"{Name} has logged in.");
        }


        public void SerializeData(string filePath)
        {
            
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize<Member>(this, options);
            File.WriteAllText(filePath, jsonData);
        }

        public static Member DeserializeData(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            
            Member member = JsonSerializer.Deserialize<Member>(jsonData);
            return member;
        }
        public void BorrowBook(Book book) //thực hiện việc mượn sách

        

        {
            book.BorrowBook();
            Console.WriteLine($"{Name} has borrowed the book: {book.Title}");
        }

        public void ReturnBook(Book book)
        {
            book.ReturnBook();
            Console.WriteLine($"{Name} has returned the book: {book.Title}");
        }

        public void SerializeData()
        {
            Console.WriteLine($"Serializing member: {Name}");
            
        }

        public void DeserializeData()
        {
            Console.WriteLine($"Deserializing member: {Name}");
           
        }

    }
}
