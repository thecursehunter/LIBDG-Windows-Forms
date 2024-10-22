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

        public void SaveInfoMember(Member member)
        {
            try 
            {
                string jsonData = JsonSerializer.Serialize(member);
                File.WriteAllText(FilePath, jsonData);
                MessageBox.Show("Member data saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Fail to save member data!: {ex.Message}", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }
    }

}
