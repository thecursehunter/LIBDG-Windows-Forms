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

        private void saveInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // lấy thông tin từ text box trong AddStudent
                int memberId = Convert.ToInt32(txtStudentID.Text);
                string name = txtStudentName.Text;
                string email = txtStudentEmail.Text;
                
                //tạo 1 cái member mới
                Member newMember = new Member(memberId, name, email);

                //lưu thông tin member vào 1 file
                Library.Instance.SerializeData("library.json");

                //Thông báo cho người dùng
                MessageBox.Show("Student information saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //xóa text box sau khi lưu
                txtStudentID.Clear();
                txtStudentEmail.Clear();
                txtStudentName.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "   Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
