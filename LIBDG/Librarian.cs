using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Librarian : Person, IBorrowable //thủ thư triển khai IBorrowable để thực hiện các hành vi mượn sách nếu cần.
    {
        public int LibrarianID { get; set; }

        public void ManageBooks()
        {
            Console.WriteLine($"{Name} is managing the books.");
        }

        public void ManageMembers()
        {
            Console.WriteLine($"{Name} is managing the members.");
        }

        public void BorrowBook(Book book)
        {
            Console.WriteLine($"{Name} is borrowing a book for the library.");
        }

        public void ReturnBook(Book book)
        {
            Console.WriteLine($"{Name} is returning a book to the library.");
        }

        public override void Login () 
        {
        
        }
    }

}
