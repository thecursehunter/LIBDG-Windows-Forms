﻿namespace LIBDG
{
    partial class CompleteBookDetail
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
            this.dataGridViewBorrowedBooks = new System.Windows.Forms.DataGridView();
            this.dataGridViewReturnedBooks = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowedBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReturnedBooks)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBorrowedBooks
            // 
            this.dataGridViewBorrowedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBorrowedBooks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.dataGridViewBorrowedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBorrowedBooks.Location = new System.Drawing.Point(16, 49);
            this.dataGridViewBorrowedBooks.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewBorrowedBooks.Name = "dataGridViewBorrowedBooks";
            this.dataGridViewBorrowedBooks.RowHeadersWidth = 51;
            this.dataGridViewBorrowedBooks.Size = new System.Drawing.Size(1330, 415);
            this.dataGridViewBorrowedBooks.TabIndex = 13;
            // 
            // dataGridViewReturnedBooks
            // 
            this.dataGridViewReturnedBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReturnedBooks.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(154)))), ((int)(((byte)(176)))));
            this.dataGridViewReturnedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReturnedBooks.Location = new System.Drawing.Point(16, 676);
            this.dataGridViewReturnedBooks.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewReturnedBooks.Name = "dataGridViewReturnedBooks";
            this.dataGridViewReturnedBooks.RowHeadersWidth = 51;
            this.dataGridViewReturnedBooks.Size = new System.Drawing.Size(1330, 415);
            this.dataGridViewReturnedBooks.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(97)))));
            this.label2.Location = new System.Drawing.Point(797, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Issued Books";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, -4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1745, 57);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(16, 612);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1747, 57);
            this.panel2.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(97)))));
            this.label3.Location = new System.Drawing.Point(792, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 34);
            this.label3.TabIndex = 3;
            this.label3.Text = "Returned Books";
            // 
            // CompleteBookDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(86)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(1805, 666);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewBorrowedBooks);
            this.Controls.Add(this.dataGridViewReturnedBooks);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CompleteBookDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CompleteBoolDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBorrowedBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReturnedBooks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewBorrowedBooks;
        private System.Windows.Forms.DataGridView dataGridViewReturnedBooks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
    }
}