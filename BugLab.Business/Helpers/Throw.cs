using System.Collections.Generic;

namespace BugLab.Business.Helpers
{
    public static class Throw
    {
        public static void NotFound(string itemName, int id)
        {
            throw new KeyNotFoundException($"The requested {itemName} with an id of {id} was not found");
        }
    }
}
