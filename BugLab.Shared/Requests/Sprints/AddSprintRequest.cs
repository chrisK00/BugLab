using System;

namespace BugLab.Shared.Requests.Sprints
{
    public class AddSprintRequest
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
