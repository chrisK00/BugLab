﻿using BugLab.Shared.Enums;

namespace BugLab.Data.Entities
{
    public class Bug : AuditableEntity
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugPriority Priority { get; set; }
        public BugStatus Status { get; set; }

        public int ProjectId { get; init; }
    }
}