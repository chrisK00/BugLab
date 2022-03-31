namespace BugLab.Shared.Enums
{
    public enum BugPriority
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }

    public enum BugStatus
    {
        Open = 0,
        InProgress = 1,
        Resolved = 2
    }

    public enum BugSortBy
    {
        Priority,
        Title
    }
}
