using library.Models.Base;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace library.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<DataManagerResponse> Add(T entity);
        Task<DataManagerResponse> Update(T entity);
        Task<DataManagerResponse> Delete(int id);
        Task<DataManagerResponse> GetSingleById(int id);
        Task<DataManagerResponse> GetAll();
        Task<DataManagerResponse> Count();
        bool CheckContains(Expression<Func<T, bool>> predicate);

    }
}
