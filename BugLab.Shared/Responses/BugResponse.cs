using BugLab.Shared.Enums;
using System;
using System.Collections.Generic;

namespace BugLab.Shared.Responses
{
    public class BugResponse
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public BugPriority Priority { get; init; }
        public BugStatus Status { get; set; }
        public DateTime Created { get; init; }
        public DateTime? Modified { get; init; }
        public string SprintTitle { get; init; }
        public int? SprintId { get; init; }
        public string ProjectTitle { get; init; }
        public int ProjectId { get; init; }
        public BugTypeResponse BugType { get; init; }
        public ICollection<CommentResponse> Comments { get; init; } = new List<CommentResponse>();
        public UserResponse CreatedBy { get; init; }
        public UserResponse ModifiedBy { get; init; }
        public UserResponse AssignedTo { get; set; }
    }
}
