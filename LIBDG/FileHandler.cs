namespace LIBDG
{
    public class FileHandler
    {
        public string FilePath { get; set; }

        // Lưu danh sách Books
        public void SaveBooksData(string filePath)
        {
            Library.Instance.SerializeBooksData(filePath);
        }

        // Tải danh sách Books
        public void LoadBooksData(string filePath)
        {
            Library.Instance.DeserializeBooksData(filePath);
        }

        // Lưu danh sách Members
        public void SaveMembersData(string filePath)
        {
            Library.Instance.SerializeMembersData(filePath);
        }

        // Tải danh sách Members
        public void LoadMembersData(string filePath)
        {
            Library.Instance.DeserializeMembersData(filePath);
        }

        // Lưu danh sách Transactions
        public void SaveTransactionsData(string filePath)
        {
            Library.Instance.SerializeTransactionsData(filePath);
        }

        // Tải danh sách Transactions
        public void LoadTransactionsData(string filePath)
        {
            Library.Instance.DeserializeTransactionsData(filePath);
        }
    }
}
