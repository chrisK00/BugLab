namespace BugLab.Shared.Requests.BugTypes
{
    public class AddBugTypeRequest
    {
        public int ProjectId { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }
    }
}
