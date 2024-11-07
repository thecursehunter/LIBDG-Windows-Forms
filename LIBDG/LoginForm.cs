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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Library.Instance.Initialize();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard dsa = new Dashboard();  
            dsa.Show();
        }
    }
}
