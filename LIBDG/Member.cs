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

        public void BorrowBook(Book book) //thực hiện việc mượn sách
        {
            Console.WriteLine($"{Name} is borrowing a book."); 
        }

        public void ReturnBook(Book book) //thực hiện việc trả sách 
        {
            Console.WriteLine($"{Name} is returning a book.");
        }

        public void SerializeData()
        {
            Console.WriteLine("Serializing Member data.");
        }

        public void DeserializeData()
        {
            Console.WriteLine("Deserializing Member data.");
        }
    }

}
