namespace BugLab.Shared.QueryParams
{
    public class BugParams : PaginationParams
    {
        private string _orderBy = "priority";

        public int? ProjectId { get; set; }
        public string OrderBy { get => _orderBy; set => _orderBy = value.ToLower(); }
        public string Title { get; set; }
    }
}
