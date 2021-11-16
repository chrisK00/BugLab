using BugLab.Shared.Enums;

namespace BugLab.Shared.Requests.Bugs
{
    public class AddBugRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BugPriority Priority { get; set; }
        public BugStatus Status { get; set; }
        public int TypeId { get; set; }
        public int ProjectId { get; set; }
    }
}
