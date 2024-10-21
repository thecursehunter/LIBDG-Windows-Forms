using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public interface IBorrowable
    {
        void BorrowBook(Book book);
        void ReturnBook(Book book);
    }
    
    // Áp dụng cho các đối tượng có khả năng mượn và trả sách, như Member và Librarian.
}
