namespace BugLab.Shared.Requests.Projects
{
    public class UpdateProjectRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
