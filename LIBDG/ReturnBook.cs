using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBDG
{
    public partial class ReturnBook : Form
    {
        private Library library; //lưu trữ dữ liệu thư viện được deserialized

        public ReturnBook()
        {
            InitializeComponent();

            //Đọc dữ liệu từ library.json khi mà form được khởi tạo
            library = LoadLibraryData("library.json");
        }

        private Library LoadLibraryData(string filePath)
        {
            //Desirialize dữ liệu thư viện từ file Json
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<Library>(jsonData);
                }
                else
                {
                    MessageBox.Show("Library data file not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading library data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void SaveLibraryData(string filePath)
        {
            //Serialize dữ liệu thư viện vào file Json
            try
            {
                string jsonData = JsonSerializer.Serialize(library);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving library data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                //lấy memberID và ISBN từ input
                int memberID = Convert.ToInt32(txtEnterEnroll.Text);
                string isbn = txtISBN.Text;

                //lấy ngày return date từ dateTimePicker
                DateTime selectedReturnDate = dateTimePickerReturnDate.Value;

                //tìm giao dịch và cập nhật ngày trả
                Transaction transactionToReturn = library.Transactions
                    .FirstOrDefault(t => t.Member.MemberID == memberID && t.Book.ISBN == isbn && !t.IsReturned);
                if (transactionToReturn != null) 
                {
                    transactionToReturn.ReturnDate = selectedReturnDate;
                    transactionToReturn.CompleteReturn();

                    //Serialized dữ liệu đã được cập nhật
                    SaveLibraryData("library.json");

                    //Thông báo người dùng đã hoàn thành
                    MessageBox.Show("Book returned successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Clear input
                    txtEnterEnroll.Clear();
                    txtISBN.Clear();
                    dateTimePickerReturnDate.Value = DateTime.Now;
                }
                else
                {
                    MessageBox.Show("No active transaction found for this book and member.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the enrollment number from the input field
                int memberId = Convert.ToInt32(txtEnterEnroll.Text);

                // Find the member in the library by Member ID
                Member foundMember = library.Members.FirstOrDefault(m => m.MemberID == memberId);

                if (foundMember != null)
                {
                    // Clear any previous data in DataGridView
                    dataGridViewStudents.Rows.Clear();

                    // Filter transactions for books currently borrowed by this member
                    List<Transaction> memberTransactions = library.Transactions
                        .Where(t => t.Member.MemberID == memberId && !t.IsReturned)
                        .ToList();

                    // If there are active transactions (books currently borrowed by the member)
                    if (memberTransactions.Count > 0)
                    {
                        // Add each active transaction's details to the DataGridView
                        foreach (Transaction transaction in memberTransactions)
                        {
                            dataGridViewStudents.Rows.Add(
                                foundMember.MemberID,
                                foundMember.Name,
                                foundMember.Email,
                                transaction.Book.Title,  // Displaying book title borrowed
                                transaction.Book.ISBN,   // Displaying book ISBN borrowed
                                transaction.BorrowDate.ToShortDateString(),  // Displaying borrow date
                                transaction.ReturnDate.ToShortDateString(),  // Displaying expected return date
                                transaction.IsOverdue() ? "Overdue" : "On Time" // Displaying overdue status
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No borrowed books found for this member.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid Member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
