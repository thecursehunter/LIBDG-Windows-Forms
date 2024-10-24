using System;
using System.Collections.Generic;
using System.IO;

using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDG
{
    public class FileHandler
    {
        public string FilePath { get; set; }

        public void SaveData(ISerializable obj, string FilePath)
        {
            obj.SerializeData(FilePath);  
        }

        public void LoadData(ISerializable obj, string FilePath)
        {
            obj.DeserializeData(FilePath);  
        }
    }

}
