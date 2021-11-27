using BugLab.Data;
using BugLab.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BugLab.Business.Extensions
{
    public static class IQueryableExtensions
    {
        /// <summary>
        ///  Gets the total amount of items in the database and then applies pagination to the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns>The query paginated and the count before pagination was applied</returns>
        public static async Task<(IQueryable<T> Query, int TotalItems)> PaginateAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize,
            CancellationToken cancellationToken)
        {
            var totalItems = await source.CountAsync(cancellationToken);

            var query = source.Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            return (query, totalItems);
        }
    }
}
