
//LibraryItem

namespace FirstProjectBook
{
    public abstract class LibraryItem
    {
        public int Id { get; }
        public string Title { get; set; }
        protected LibraryItem(int id, string title)
        {
            Id = id;
            Title = title;
        }
        public abstract string GetInfo();
    }
}
