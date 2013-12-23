
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Reflection;
namespace DataAccess.Utils
{
    public static class LinqExtensions
    {
        public static IQueryable<T> NullableWhere<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression)
        {
            object queryValue = GetLocalPropertyExpressionValue(expression);
            if (queryValue != null)
                return query.Where(expression);
            else
                return query;
        }


        private static object GetClassPropertyExpressionValue<T>(Expression<Func<T, bool>> expression)
        {
            var binaryexp = expression.Body as BinaryExpression;
            if (binaryexp == null) return null;
            var criteriaProperty = binaryexp.Right as MemberExpression;
            var criteriaClass = criteriaProperty.Expression as MemberExpression;
            var criteriaClassConstant = criteriaClass.Expression as ConstantExpression;
            object criteriaObjectWithValues = ((FieldInfo)criteriaClass.Member).GetValue(criteriaClassConstant.Value);
            var propertyValue =  ((PropertyInfo)criteriaProperty.Member).GetValue(criteriaObjectWithValues, null);
            return propertyValue;
        }

        private static object GetLocalPropertyExpressionValue<T>(Expression<Func<T, bool>> expression)
        {
            var binaryexp = expression.Body as BinaryExpression;
            if (binaryexp == null) return null;
            var criteriaProperty = binaryexp.Right as MemberExpression;
            var criteriaClassConstant = criteriaProperty.Expression as ConstantExpression;
            object propertyValue = ((PropertyInfo)criteriaProperty.Member).GetValue(criteriaClassConstant.Value, null);
            return propertyValue;
        }
    }
}
