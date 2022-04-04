using System.Collections.Generic;

namespace BugLab.Shared.Responses
{
    public class SprintResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<BugResponse> Bugs { get; set; }
        public string ProjectTitle { get; set; }
    }
}
