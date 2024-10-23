using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LIBDG
{
    [Serializable]
    public class Member : Person, IBorrowable, ISerializable
    {
        public int MemberID { get; set; }

        public Member() { }
        protected Member(SerializationInfo info, StreamingContext context)
        {
            MemberID = info.GetInt32("MemberID");
        }
        public void GetObjectData (SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MemberID", MemberID);
        }

        public void SerializeData(string filePath)
        {
            
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonData = JsonSerializer.Serialize<Member>(this, options);
            File.WriteAllText(filePath, jsonData);
        }

        public static Member DeserializeData(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            
            Member member = JsonSerializer.Deserialize<Member>(jsonData);
            return member;
        }
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
