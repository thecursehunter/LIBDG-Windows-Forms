using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBDG
{
    public interface ISerializable
    {
        void SerializeData();
        void DeserializeData();
    }
    //Dành cho các lớp cần khả năng lưu trữ dữ liệu ra file, như Book, Member, và Library.
}
