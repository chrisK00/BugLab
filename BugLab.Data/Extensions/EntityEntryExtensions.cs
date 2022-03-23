using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq.Expressions;

namespace BugLab.Data.Extensions
{
    public static class EntityEntryExtensions
    {
        public static void SetProperty<TEntity, TProperty>(this EntityEntry<TEntity> entry,
            Expression<Func<TEntity, TProperty>> propertyExpression,
            TProperty value)
            where TEntity : class
        {
            entry.Property(propertyExpression).CurrentValue = value;
        }
    }
}
