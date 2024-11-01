namespace LIBDG
{
    public class FileHandler
    {
        public string FilePath { get; set; }

        // Lưu danh sách Books
        public void SaveBooksData(Library library, string filePath)
        {
            library.SerializeBooksData(filePath);
        }

        // Tải danh sách Books
        public void LoadBooksData(Library library, string filePath)
        {
            library.DeserializeBooksData(filePath);
        }

        // Lưu danh sách Members
        public void SaveMembersData(Library library, string filePath)
        {
            library.SerializeMembersData(filePath);
        }

        // Tải danh sách Members
        public void LoadMembersData(Library library, string filePath)
        {
            library.DeserializeMembersData(filePath);
        }

        // Lưu danh sách Transactions
        public void SaveTransactionsData(Library library, string filePath)
        {
            library.SerializeTransactionsData(filePath);
        }

        // Tải danh sách Transactions
        public void LoadTransactionsData(Library library, string filePath)
        {
            library.DeserializeTransactionsData(filePath);
        }
    }
}
