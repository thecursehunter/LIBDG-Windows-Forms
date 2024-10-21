using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class BorrowTransaction : Transaction 
    {
        public void ExtendBorrowing()
        {
            Console.WriteLine("Extending the borrowing period.");
        }
    }

}
