using System;
using System.Collections.Generic;

namespace BugLab.Data.Entities
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Bug> Bugs { get; set; }
        public Project Project { get; private set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}