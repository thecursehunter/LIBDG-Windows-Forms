using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public class FileHandler
    {
        public string FilePath { get; set; }

        public void SerializeData(ISerializable obj)
        {
            Console.WriteLine($"Serializing data to {FilePath}");
            obj.SerializeData();
        }

        public void DeserializeData(ISerializable obj)
        {
            Console.WriteLine($"Deserializing data from {FilePath}");
            obj.DeserializeData();
        }
    }

}
