using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDG
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Member newMember = new Member(2, "TBB", "TBB.doe@example.com");

            //FileHandler fileHandler = new FileHandler();
            //string filePath = "test.json";

            
            //fileHandler.SaveData(newMember, filePath);

            
            //Member newMember1 = new Member();
            //fileHandler.LoadData(newMember, filePath);

            //MessageBox.Show($"Name: {newMember.Name}, Email: {newMember.Email}, MemberID: {newMember.MemberID}");
            Application.Run(new LoginForm());

        }
    }
}
