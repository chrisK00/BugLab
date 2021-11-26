namespace BugLab.Shared.Responses
{
    public class ProjectResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public int TotalBugs { get; set; }
        public int TotalHighPriorityBugs { get; set; }
    }
}
