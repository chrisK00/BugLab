﻿using BugLab.Shared.Enums;

namespace BugLab.Shared.Requests.Bugs
{
    public class UpdateBugRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugPriority Priority { get; set; }
        public BugStatus Status { get; set; }
        public int TypeId { get; set; }
        public string AssignedToId { get; set; }
        public int? SprintId { get; set; }
    }
}
