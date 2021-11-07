namespace BugLab.Shared.QueryParams
{
    public class PaginationParams
    {
        private const int _min = 1;
        public const int MaxPageSize = 20;
        private int _pageSize = 10;
        private int _pageNumber = 1;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < _min ? _min : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value is > MaxPageSize or < _min ? MaxPageSize : value;
        }
    }
}