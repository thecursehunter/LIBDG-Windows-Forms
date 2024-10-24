﻿using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Exit?", "Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ToolStripAddNewBooks_Click(object sender, EventArgs e)
        {
            AddBook abs = new AddBook();
            abs.Show();
        }

        private void ToolStripViewBooks_Click(object sender, EventArgs e)
        {
            ViewBook vbs = new ViewBook();
            vbs.Show();
        }

        private void ToolStripAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent ads = new AddStudent();
            ads.Show();
        }
    }
}
