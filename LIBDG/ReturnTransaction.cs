using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class ReturnTransaction : Transaction
    {
        public void ProcessReturn()
        {
            Console.WriteLine("Processing the return of the book.");
        }
    }

}
