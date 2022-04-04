using System;
using System.Collections.Generic;

namespace BugLab.Shared.Responses
{
    public class SprintDetailsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<BugResponse> Bugs { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
