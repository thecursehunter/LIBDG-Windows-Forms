using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Library : ISerializable
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public List<Transaction> Transactions { get; set; }

        public void AddBook()
        {
            Console.WriteLine("Adding a new book to the library.");
        }

        public void RemoveBook()
        {
            Console.WriteLine("Removing a book from the library.");
        }

        public void RegisterMember()
        {
            Console.WriteLine("Registering a new member.");
        }

        public void GenerateReport()
        {
            Console.WriteLine("Generating a library report.");
        }

        public void SerializeData(string FilePath)
        {
            Console.WriteLine("Serializing Library data.");
        }

        public void DeserializeData(string FilePath)
        {
            Console.WriteLine("Deserializing Library data.");
        }
    }

}
