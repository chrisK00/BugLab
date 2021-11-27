namespace BugLab.Shared.Responses
{
    public class DashboardResponse
    {
        public int TotalOpenBugs { get; set; }
        public int TotalInProgressBugs { get; set; }
        public int TotalHighPrioritizedOpenBugs { get; set; }
        public int TotalAssignedBugs { get; set; }
        public CommentResponse LatestComment { get; set; }
        public BugResponse LatestBug { get; set; }
        public BugResponse LatestUpdatedBug { get; set; }
    }
}
