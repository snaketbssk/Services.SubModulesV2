using System.Linq.Expressions;

namespace Services.SubModules.LogicLayers.Extensions
{
    /// <summary>
    /// Provides extension methods for combining expressions using logical OR.
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Combines two expressions using the logical OR operator.
        /// </summary>
        /// <typeparam name="T">The type of the expression parameter.</typeparam>
        /// <param name="expr1">The first expression.</param>
        /// <param name="expr2">The second expression.</param>
        /// <returns>A new combined expression.</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            // Create an invocation expression for the second expression using parameters from the first expression
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters);

            // Combine the body of the first expression and the invoked expression using the OR logical operator
            var result = Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
            return result;
        }
    }
}
