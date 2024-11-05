using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void buttonAddMember_Click(object sender, EventArgs e)
        {                      
            string name = textBoxName.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (!int.TryParse(textBoxMemberID.Text, out int memberID) || memberID <= 0 ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please check the member information. Ensure all fields are filled and valid.");
                return;
            }

            Member newMember = new Member(memberID, name, email);
         
            Library.Instance.RegisterMember(newMember);

            FileHandler fileHandler = new FileHandler();
            string membersFilePath = "members.json";
            fileHandler.SaveMembersData(membersFilePath);

            textBoxMemberID.Clear();
            textBoxName.Clear();
            textBoxEmail.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            textBoxMemberID.Clear();
            textBoxName.Clear();
            textBoxEmail.Clear();
        }
    }
}
