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
            dataGridViewMembers.CellClick += dataGridViewMembers_CellClick;
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
        private void dataGridViewMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
               
                DataGridViewRow selectedRow = dataGridViewMembers.Rows[e.RowIndex];

               
                txtStudentID.Text = selectedRow.Cells["MemberID"].Value.ToString();
                txtStudentName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtStudentEmail.Text = selectedRow.Cells["Email"].Value.ToString();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int memberID = int.Parse(txtStudentID.Text);
            string name = txtStudentName.Text;
            string email = txtStudentEmail.Text;

            Member updatedMember = new Member(memberID, name, email);

            Library.Instance.UpdateMemberInfo(updatedMember);

            Library.Instance.SerializeMembersData("members.json");
            MessageBox.Show("Member information has been updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int memberID = int.Parse(txtStudentID.Text);

            Library.Instance.RemoveMember(memberID);

            Library.Instance.SerializeMembersData("members.json");
        }
    }
}

