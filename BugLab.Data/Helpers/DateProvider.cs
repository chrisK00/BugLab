using System;

namespace BugLab.Data.Helpers
{
    public class DateProvider : IDateProvider
    {
        public DateTime UtcDate => DateTime.UtcNow;
    }
}
