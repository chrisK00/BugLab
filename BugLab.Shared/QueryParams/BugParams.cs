using BugLab.Shared.Enums;

namespace BugLab.Shared.QueryParams
{
    public class BugParams : PaginationParams
    {
        public int? ProjectId { get; set; }
        public BugSortBy SortBy { get; set; }
        public SortDirection Sort { get; set; }
        public string Title { get; set; }
    }
}
