using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class Book : ISerializable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int AvailableCopies { get; set; }

        public void SerializeData()
        {
            Console.WriteLine("Serializing Book data.");
        }

        public void DeserializeData()
        {
            Console.WriteLine("Deserializing Book data.");
        }
    }

}
