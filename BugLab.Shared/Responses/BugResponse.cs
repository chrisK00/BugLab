using BugLab.Shared.Enums;

namespace BugLab.Shared.Responses
{
    public class BugResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public BugPriority Priority { get; init; }
        public BugStatus Status { get; init; }
    }
}
