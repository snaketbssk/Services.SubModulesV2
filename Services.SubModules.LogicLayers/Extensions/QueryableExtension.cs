using System.Linq.Expressions;
using System.Reflection;

namespace Services.SubModules.LogicLayers.Extensions
{
    /// <summary>
    /// Provides extension methods for building dynamic filtering conditions on IQueryable entities.
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// Filters entities by comparing a specified property with a list of values using the Equals operator.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entities">The IQueryable of entities to filter.</param>
        /// <param name="propertyName">The name of the property to filter on.</param>
        /// <param name="values">The list of values to compare with the property.</param>
        /// <returns>An IQueryable containing filtered entities.</returns>
        public static IQueryable<TEntity> Equals<TEntity>(this IQueryable<TEntity> entities,
                                                          string propertyName,
                                                          IEnumerable<string>? values)
            where TEntity : class
        {
            if (string.IsNullOrEmpty(propertyName) || values == null || !values.Any())
                return entities;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, propertyName);
            var valueExpressions = values.Select(value => Expression.Constant(value)).ToList();

            Expression? filterExpression = null;

            foreach (var valueExpression in valueExpressions)
            {
                var equalsExpression = Expression.Equal(property, valueExpression);
                filterExpression = filterExpression == null
                    ? equalsExpression
                    : Expression.OrElse(filterExpression, equalsExpression); // Use Expression.OrElse for OR operation
            }

            if (filterExpression == null)
                return entities;

            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
            var result = entities.Where(lambda);

            return result;
        }

        /// <summary>
        /// Filters entities by comparing a specified property with a list of values using the Not Equals operator.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entities">The IQueryable of entities to filter.</param>
        /// <param name="propertyName">The name of the property to filter on.</param>
        /// <param name="values">The list of values to compare with the property.</param>
        /// <returns>An IQueryable containing filtered entities.</returns>
        public static IQueryable<TEntity> NotEquals<TEntity>(this IQueryable<TEntity> entities,
                                                             string propertyName,
                                                             IEnumerable<string>? values)
            where TEntity : class
        {
            if (string.IsNullOrEmpty(propertyName) || values == null || !values.Any())
                return entities;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, propertyName);
            var valueExpressions = values.Select(value => Expression.Constant(value)).ToList();

            Expression? filterExpression = null;

            foreach (var valueExpression in valueExpressions)
            {
                var notEqualsExpression = Expression.NotEqual(property, valueExpression);
                filterExpression = filterExpression == null
                    ? notEqualsExpression
                    : Expression.AndAlso(filterExpression, notEqualsExpression); // Use Expression.AndAlso for AND operation
            }

            if (filterExpression == null)
                return entities;

            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
            var result = entities.Where(lambda);

            return result;
        }

        /// <summary>
        /// Filters entities by checking if a specified property contains any of the given values.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entities">The IQueryable of entities to filter.</param>
        /// <param name="propertyName">The name of the property to filter on.</param>
        /// <param name="values">The list of values to search for in the property.</param>
        /// <returns>An IQueryable containing filtered entities.</returns>
        public static IQueryable<TEntity> Contains<TEntity>(this IQueryable<TEntity> entities,
                                                            string propertyName,
                                                            IEnumerable<string>? values)
            where TEntity : class
        {
            if (string.IsNullOrEmpty(propertyName) || values == null || !values.Any())
                return entities;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, propertyName);
            var valueExpressions = values.Select(value => Expression.Constant(value)).ToList();

            Expression? filterExpression = null;

            foreach (var valueExpression in valueExpressions)
            {
                var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                var containsExpression = Expression.Call(property, containsMethod, valueExpression);
                filterExpression = filterExpression == null
                    ? containsExpression
                    : Expression.OrElse(filterExpression, containsExpression); // Use Expression.OrElse for OR operation
            }

            if (filterExpression == null)
                return entities;

            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
            var result = entities.Where(lambda);

            return result;
        }

        /// <summary>
        /// Filters entities by checking if a specified property does not contain any of the given values.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="entities">The IQueryable of entities to filter.</param>
        /// <param name="propertyName">The name of the property to filter on.</param>
        /// <param name="values">The list of values to exclude from the property.</param>
        /// <returns>An IQueryable containing filtered entities.</returns>
        public static IQueryable<TEntity> NotContains<TEntity>(this IQueryable<TEntity> entities,
                                                               string propertyName,
                                                               IEnumerable<string>? values)
            where TEntity : class
        {
            if (string.IsNullOrEmpty(propertyName) || values == null || !values.Any())
                return entities;

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var property = Expression.Property(parameter, propertyName);
            var valueExpressions = values.Select(value => Expression.Constant(value)).ToList();

            Expression? filterExpression = null;

            foreach (var valueExpression in valueExpressions)
            {
                var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
                var containsExpression = Expression.Call(property, containsMethod, valueExpression);
                var notContainsExpression = Expression.Not(containsExpression);
                filterExpression = filterExpression == null
                    ? notContainsExpression
                    : Expression.AndAlso(filterExpression, notContainsExpression); // Use Expression.AndAlso for AND operation
            }

            if (filterExpression == null)
                return entities;

            var lambda = Expression.Lambda<Func<TEntity, bool>>(filterExpression, parameter);
            var result = entities.Where(lambda);

            return result;
        }
    }
}
