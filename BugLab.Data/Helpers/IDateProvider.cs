using System;

namespace BugLab.Data.Helpers
{
    public interface IDateProvider
    {
        DateTime UtcDate { get; }
    }
}
