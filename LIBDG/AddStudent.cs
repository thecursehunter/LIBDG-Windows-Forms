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
            
            if (!int.TryParse(textBoxMemberID.Text, out int memberID))
            {
                MessageBox.Show("Please enter a valid Member ID.");
                return;
            }

            string name = textBoxName.Text;
            string email = textBoxEmail.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please check again student info");
                return;
            }

            
            Member newMember = new Member(memberID, name, email);

         
            Library.Instance.RegisterMember(newMember);

            FileHandler fileHandler = new FileHandler();
            string membersFilePath = "members.json";
            fileHandler.SaveMembersData(membersFilePath);

            MessageBox.Show("Member added and saved successfully!");

            
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
