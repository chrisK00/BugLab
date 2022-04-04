using System;

namespace BugLab.Shared.Responses
{
    public class SprintForListResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
