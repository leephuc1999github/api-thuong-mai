using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace library.Interfaces.Base
{
    public interface IQueryRepository<T> where T : class
    {
        IQueryable<T> OrderBy<T>(IQueryable<T> source, string propertyName);
        IQueryable<T> OrderByDescending<T>(IQueryable<T> source, string propertyName);
    }
}
