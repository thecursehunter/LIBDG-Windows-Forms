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
            this.ToolStripissueBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripReturnBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripCompleteBookDetails = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ToolStripissueBooks,
            this.ToolStripReturnBooks,
            this.ToolStripCompleteBookDetails,
            this.ToolStripExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
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
            this.ToolStripAddNewBooks.Size = new System.Drawing.Size(165, 22);
            this.ToolStripAddNewBooks.Text = "Add New Books";
            this.ToolStripAddNewBooks.Click += new System.EventHandler(this.ToolStripAddNewBooks_Click);
            // 
            // ToolStripViewBooks
            // 
            this.ToolStripViewBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.ToolStripViewBooks.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripViewBooks.Image")));
            this.ToolStripViewBooks.Name = "ToolStripViewBooks";
            this.ToolStripViewBooks.Size = new System.Drawing.Size(165, 22);
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
            this.ToolStripAddStudent.Size = new System.Drawing.Size(158, 22);
            this.ToolStripAddStudent.Text = "Add Student";
            this.ToolStripAddStudent.Click += new System.EventHandler(this.ToolStripAddStudent_Click);
            // 
            // StripMenuViewStudent
            // 
            this.StripMenuViewStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.StripMenuViewStudent.Image = ((System.Drawing.Image)(resources.GetObject("StripMenuViewStudent.Image")));
            this.StripMenuViewStudent.Name = "StripMenuViewStudent";
            this.StripMenuViewStudent.Size = new System.Drawing.Size(158, 22);
            this.StripMenuViewStudent.Text = "View Student";
            this.StripMenuViewStudent.Click += new System.EventHandler(this.StripMenuViewStudent_Click);
            // 
            // ToolStripissueBooks
            // 
            this.ToolStripissueBooks.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripissueBooks.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ToolStripissueBooks.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripissueBooks.Image")));
            this.ToolStripissueBooks.Name = "ToolStripissueBooks";
            this.ToolStripissueBooks.Size = new System.Drawing.Size(130, 38);
            this.ToolStripissueBooks.Text = "Issue Books";
            this.ToolStripissueBooks.Click += new System.EventHandler(this.ToolStripissueBooks_Click);
            // 
            // ToolStripReturnBooks
            // 
            this.ToolStripReturnBooks.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripReturnBooks.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ToolStripReturnBooks.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripReturnBooks.Image")));
            this.ToolStripReturnBooks.Name = "ToolStripReturnBooks";
            this.ToolStripReturnBooks.Size = new System.Drawing.Size(137, 38);
            this.ToolStripReturnBooks.Text = "Return Books";
            this.ToolStripReturnBooks.Click += new System.EventHandler(this.ToolStripReturnBooks_Click);
            // 
            // ToolStripCompleteBookDetails
            // 
            this.ToolStripCompleteBookDetails.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripCompleteBookDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ToolStripCompleteBookDetails.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripCompleteBookDetails.Image")));
            this.ToolStripCompleteBookDetails.Name = "ToolStripCompleteBookDetails";
            this.ToolStripCompleteBookDetails.Size = new System.Drawing.Size(200, 38);
            this.ToolStripCompleteBookDetails.Text = "Complete Book Details";
            this.ToolStripCompleteBookDetails.Click += new System.EventHandler(this.ToolStripCompleteBookDetails_Click);
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
        private System.Windows.Forms.ToolStripMenuItem ToolStripissueBooks;
        private System.Windows.Forms.ToolStripMenuItem ToolStripReturnBooks;
        private System.Windows.Forms.ToolStripMenuItem ToolStripCompleteBookDetails;
        private System.Windows.Forms.ToolStripMenuItem ToolStripExit;
    }
}