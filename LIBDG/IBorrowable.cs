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
    
    
}
