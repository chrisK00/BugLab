namespace BugLab.Shared.QueryParams
{
    public class UserParams : PaginationParams
    {
        public string Email { get; set; }
        public int? NotInProjectId { get; set; }
    }
}
