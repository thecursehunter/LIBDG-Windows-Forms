using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using LIBDG;
namespace LIBDG
{
 
    public class Library 
    {
        private static Library _instance;

        public static Library Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Library();
                }
                return _instance;
            }
        }

        // Instances of each separate list class
        public ListOfBooks Books { get; private set; }
        public ListOfMembers Members { get; private set; }
        public ListOfTransactions Transactions { get; private set; }

        private Library()
        {
            Books = new ListOfBooks();
            Members = new ListOfMembers();
            Transactions = new ListOfTransactions();

            
        }
        public void Initialize()
        {
            LoadAllData();
        }
        // Serialization of the entire library's data
        public void SaveAllData()
        {
            try
            {
                Books.SerializeData("books.json");
                Members.SerializeData("members.json");
                Transactions.SerializeData("transactions.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving library data: {ex.Message}");
            }
        }

        public void LoadAllData()
        {
            try
            {
                Books = new ListOfBooks();
                Members = new ListOfMembers();
                Transactions = new ListOfTransactions();

                Books.DeserializeData("books.json");
                Members.DeserializeData("members.json");
                Transactions.DeserializeData("transactions.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading library data: {ex.Message}");
            }
        }
       
    }
}
