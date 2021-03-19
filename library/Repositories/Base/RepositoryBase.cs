using library.Interfaces.Base;
using library.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace library.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private AppDbContext _dbContext;
        private DbSet<T> _dbSet;
        #endregion
        protected RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        #region Implementation
        public async Task<DataManagerResponse> Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
            var allData = _dbSet.ToList();
            return new DataManagerResponse
            {
                Method = MethodRequest.POST,
                StatusCode = 200,
                Result = allData
            };
        }
        public async Task<DataManagerResponse> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return new DataManagerResponse
            {
                Method = MethodRequest.PUT,
                StatusCode = 200,
                Result = entity
            };

        }
        public async Task<DataManagerResponse> GetSingleById(int id)
        {
            return new DataManagerResponse 
            {
                Method = MethodRequest.GET,
                StatusCode = 200,
                Result = _dbSet.Find(id)
            };
        }
        public async Task<DataManagerResponse> Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if(entity == null)
            {
                return new DataManagerResponse
                {
                    Method = MethodRequest.DELETE,
                    StatusCode = 400,
                    Message = "not found enity has " + id,
                    Result = null
                };
            }
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
            return new DataManagerResponse
            {
                Method = MethodRequest.DELETE,
                StatusCode = 200,
                Result = _dbSet.ToList()
            };
        }
        public async Task<DataManagerResponse> GetAll()
        {
            return new DataManagerResponse
            {
                Method = MethodRequest.GET,
                StatusCode = 200,
                Result = _dbSet.ToList()
            };
        }
        public virtual bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count<T>(predicate) > 0;
        }
        public async Task<DataManagerResponse> Count()
        {
            return new DataManagerResponse
            {
                Method = MethodRequest.GET,
                StatusCode = 200,
                Result = _dbSet.Count()
            };
        }
        #endregion




        #region method_hide
        //public void Delete(T entity)
        //{
        //    _dbSet.Remove(entity);
        //    _dbContext.SaveChanges();
        //}
        //public virtual int Count(Expression<Func<T, bool>> where)
        //{
        //    return _dbSet.Count(where);
        //}
        //public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        //{
        //    IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();
        //    foreach (T obj in objects)
        //        _dbSet.Remove(obj);
        //    _dbContext.SaveChanges();
        //}
        //public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        //{
        //    return _dbSet.Where(where).ToList();
        //}
        //public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        //{
        //    return GetAll(includes).FirstOrDefault(expression);
        //}
        //public virtual IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        //{
        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = _dbSet.Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return query.Where<T>(predicate).AsQueryable<T>();
        //    }

        //    return _dbSet.Where<T>(predicate).AsQueryable<T>();
        //}
        //public virtual IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        //{
        //    int skipCount = index * size;
        //    IQueryable<T> _resetSet;

        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = _dbSet.Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
        //    }
        //    else
        //    {
        //        _resetSet = predicate != null ? _dbSet.Where<T>(predicate).AsQueryable() : _dbSet.AsQueryable();
        //    }

        //    _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //    total = _resetSet.Count();
        //    return _resetSet.AsQueryable();
        //}

        #endregion
    }
}
