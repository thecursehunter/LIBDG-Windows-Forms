using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace LIBDG
{
    public class ListOfTransactions : ISerializable
    {
        public List<Transaction> Transactions { get; set; }

        public ListOfTransactions()
        {
            Transactions = new List<Transaction>();
        }

        public void SerializeData(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, JsonSerializer.Serialize(Transactions));
              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error serializing transactions data: {ex.Message}");
            }
        }

        public void DeserializeData(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                   
                    string jsonData = File.ReadAllText(filePath);
                    
                    Transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonData) ?? new List<Transaction>();
                   
                }
            }
            catch (Exception)
            {
               
            }
        }
        public List<Transaction> GetUnreturnedTransactionsForMember(int memberId)
        {
            List<Transaction> unreturnedTransactions = new List<Transaction>();
            foreach (Transaction transaction in Transactions)
            {
                
                if (transaction.Member.MemberID == memberId && !transaction.IsReturned)
                {
                    unreturnedTransactions.Add(transaction);
                }
            }
            return unreturnedTransactions;
        }
    }
}
