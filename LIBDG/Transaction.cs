using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public void CreateTransaction()
        {
            Console.WriteLine("Creating a new transaction.");
        }

        public void CompleteTransaction()
        {
            Console.WriteLine("Completing the transaction.");
        }
    }

}
