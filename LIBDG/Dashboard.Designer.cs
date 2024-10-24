namespace LIBDG
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.booksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripAddNewBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripViewBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuViewStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.issueBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeBookDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(216)))), ((int)(((byte)(177)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(34, 34);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.booksToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.issueBooksToolStripMenuItem,
            this.returnBooksToolStripMenuItem,
            this.completeBookDetailsToolStripMenuItem,
            this.ToolStripExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // booksToolStripMenuItem
            // 
            this.booksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripAddNewBooks,
            this.ToolStripViewBooks});
            this.booksToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.booksToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.booksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("booksToolStripMenuItem.Image")));
            this.booksToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.booksToolStripMenuItem.Name = "booksToolStripMenuItem";
            this.booksToolStripMenuItem.Size = new System.Drawing.Size(88, 38);
            this.booksToolStripMenuItem.Text = "Books";
            // 
            // ToolStripAddNewBooks
            // 
            this.ToolStripAddNewBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.ToolStripAddNewBooks.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripAddNewBooks.Image")));
            this.ToolStripAddNewBooks.Name = "ToolStripAddNewBooks";
            this.ToolStripAddNewBooks.Size = new System.Drawing.Size(198, 40);
            this.ToolStripAddNewBooks.Text = "Add New Books";
            this.ToolStripAddNewBooks.Click += new System.EventHandler(this.ToolStripAddNewBooks_Click);
            // 
            // ToolStripViewBooks
            // 
            this.ToolStripViewBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.ToolStripViewBooks.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripViewBooks.Image")));
            this.ToolStripViewBooks.Name = "ToolStripViewBooks";
            this.ToolStripViewBooks.Size = new System.Drawing.Size(198, 40);
            this.ToolStripViewBooks.Text = "View Books";
            this.ToolStripViewBooks.Click += new System.EventHandler(this.ToolStripViewBooks_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripAddStudent,
            this.StripMenuViewStudent});
            this.studentToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.studentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("studentToolStripMenuItem.Image")));
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(102, 38);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // ToolStripAddStudent
            // 
            this.ToolStripAddStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.ToolStripAddStudent.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripAddStudent.Image")));
            this.ToolStripAddStudent.Name = "ToolStripAddStudent";
            this.ToolStripAddStudent.Size = new System.Drawing.Size(198, 40);
            this.ToolStripAddStudent.Text = "Add Student";
            this.ToolStripAddStudent.Click += new System.EventHandler(this.ToolStripAddStudent_Click);
            // 
            // StripMenuViewStudent
            // 
            this.StripMenuViewStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.StripMenuViewStudent.Image = ((System.Drawing.Image)(resources.GetObject("StripMenuViewStudent.Image")));
            this.StripMenuViewStudent.Name = "StripMenuViewStudent";
            this.StripMenuViewStudent.Size = new System.Drawing.Size(198, 40);
            this.StripMenuViewStudent.Text = "View Student";
            this.StripMenuViewStudent.Click += new System.EventHandler(this.StripMenuViewStudent_Click);
            // 
            // issueBooksToolStripMenuItem
            // 
            this.issueBooksToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issueBooksToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.issueBooksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("issueBooksToolStripMenuItem.Image")));
            this.issueBooksToolStripMenuItem.Name = "issueBooksToolStripMenuItem";
            this.issueBooksToolStripMenuItem.Size = new System.Drawing.Size(130, 38);
            this.issueBooksToolStripMenuItem.Text = "Issue Books";
            // 
            // returnBooksToolStripMenuItem
            // 
            this.returnBooksToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooksToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.returnBooksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("returnBooksToolStripMenuItem.Image")));
            this.returnBooksToolStripMenuItem.Name = "returnBooksToolStripMenuItem";
            this.returnBooksToolStripMenuItem.Size = new System.Drawing.Size(137, 38);
            this.returnBooksToolStripMenuItem.Text = "Return Books";
            // 
            // completeBookDetailsToolStripMenuItem
            // 
            this.completeBookDetailsToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeBookDetailsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.completeBookDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("completeBookDetailsToolStripMenuItem.Image")));
            this.completeBookDetailsToolStripMenuItem.Name = "completeBookDetailsToolStripMenuItem";
            this.completeBookDetailsToolStripMenuItem.Size = new System.Drawing.Size(200, 38);
            this.completeBookDetailsToolStripMenuItem.Text = "Complete Book Details";
            // 
            // ToolStripExit
            // 
            this.ToolStripExit.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ToolStripExit.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripExit.Image")));
            this.ToolStripExit.Name = "ToolStripExit";
            this.ToolStripExit.Size = new System.Drawing.Size(81, 38);
            this.ToolStripExit.Text = "Exit";
            this.ToolStripExit.Click += new System.EventHandler(this.ToolStripExit_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem booksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAddNewBooks;
        private System.Windows.Forms.ToolStripMenuItem ToolStripViewBooks;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripAddStudent;
        private System.Windows.Forms.ToolStripMenuItem StripMenuViewStudent;
        private System.Windows.Forms.ToolStripMenuItem issueBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeBookDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripExit;
    }
}