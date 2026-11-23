namespace FirstProjectBook
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(int id, string title, int issueNumber)
            :base(id, title)
        {
            IssueNumber = issueNumber;
        }
        public override string GetInfo()
        {
            return $"Magazine: {Title}, Issue: {IssueNumber}";

        }
    }
}