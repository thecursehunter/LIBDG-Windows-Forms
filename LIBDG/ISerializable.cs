using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LIBDG
{
    public interface ISerializable
    {
        void SerializeData(string FilePath);
        void DeserializeData(string FilePath);
    }
    
}
