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

        public Member(int memberID, string name, string email) : base(name, email) 
        {
        MemberID = memberID; 
        } 

        public override void Login()
        {
            Console.WriteLine($"{Name} đã đăng nhập");
        }
        

        public void SerializeData()
        {
            Console.WriteLine($"Serializing Member: {Name}.");
        }

        public void DeserializeData()
        {
            Console.WriteLine($"Deserializing Member: {Name}."); 
        }

        public void BorrowBook(Book book) //thực hiện việc mượn sách
        {
            book.BorrowBook();
            Console.WriteLine($"{Name} đã mượn sách: {book.Title}.");
        }

        public void ReturnBook(Book book) //thực hiện việc trả sách 
        {
            book.ReturnBook();
            Console.WriteLine($"{Name} đã trả sách: {book.Title}.");
        }

        
    }

}
