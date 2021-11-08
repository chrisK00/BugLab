using BugLab.Shared.Enums;
using System;

namespace BugLab.Shared.Responses
{
    public class BugResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public BugPriority Priority { get; init; }
        public BugStatus Status { get; init; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string ProjectTitle { get; set; }
        public int ProjectId { get; set; }
    }
}
