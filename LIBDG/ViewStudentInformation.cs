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
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

       
            private void buttonSearchMember_Click(object sender, EventArgs e)
            {
                string searchTerm = textBoxSearchMember.Text.Trim();

                
                if (string.IsNullOrEmpty(searchTerm))
                {
                    MessageBox.Show("Please enter a Name to search.");
                    return; 
                }

                
                string membersFilePath = "members.json";

              
                List<Member> foundMembers = Library.Instance.LoadMembersFromJsonAndFind(membersFilePath, searchTerm);

              
                if (foundMembers.Count == 0)
                {
                    MessageBox.Show("No member found with the provided information.");
                    return;
                }

                
                DisplayMembersInDataGridView(foundMembers);
            }
        private void DisplayMembersInDataGridView(List<Member> members)
        {
            
            dataGridViewMembers.Rows.Clear();

        
            if (dataGridViewMembers.Columns.Count == 0)
            {
                dataGridViewMembers.Columns.Add("MemberID", "Member ID");
                dataGridViewMembers.Columns.Add("Name", "Name");
                dataGridViewMembers.Columns.Add("Email", "Email");
            }

            foreach (Member member in members)
            {
                dataGridViewMembers.Rows.Add(member.MemberID, member.Name, member.Email);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

