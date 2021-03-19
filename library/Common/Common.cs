using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace library.Common
{
    public class Common
    {
        public static string ToLower(string para)
        {
            return para.ToLower();
        }
        public static string ToJson(object para)
        {
            return JsonConvert.SerializeObject(para);
        }
        public static IQueryable<T> OrderBy<T>(IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IQueryable<T> OrderByDescending<T>(IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }

    }
}
