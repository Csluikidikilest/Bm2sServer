using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Services
{
  public static class OrderByExtensions
  {
    public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool ascending, params object[] values)
    {
      var type = typeof(T);
      var property = type.GetProperty(ordering);
      if (property == null)
      {
        property = type.GetProperty("Id");
      }

      var parameter = Expression.Parameter(type, "p");
      var propertyAccess = Expression.MakeMemberAccess(parameter, property);
      var orderByExp = Expression.Lambda(propertyAccess, parameter);
      MethodCallExpression resultExp = Expression.Call(typeof(Queryable), ascending ? "OrderBy" : "OrderByDescending", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
      return source.Provider.CreateQuery<T>(resultExp);
    }
  }
}
