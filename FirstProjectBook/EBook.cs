
namespace FirstProjectBook
{
    public class EBook : Book
    {
        public double FileSizeMB { get; set; }

        public EBook(
            int id,
            string title,
            string author,
            bool isAvailable,
            double fileSizeMB)
            : base(id, title, author, isAvailable)
        {
            FileSizeMB = fileSizeMB;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()}, File Size: {FileSizeMB} MB";
        }
    }
}
