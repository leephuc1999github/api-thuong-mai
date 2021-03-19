using library.Interfaces;
using library.Models;
using library.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static library.Common.Common;

namespace library.Repositories
{
    public class DoiTacRepository : RepositoryBase<DoiTac> , IDoiTacRepository 
    {
        private AppDbContext _dbContext;
        public DoiTacRepository(AppDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<DataManagerResponse> Gets(int skip = 0, int top = 100, string q = null, string includes = null , string orderBys = null)
        {
            ICollection<string> collectionOrderBy = null;
            ICollection<string> collectionInclude = null;
            if(includes != null)
            {
                collectionInclude = new Regex(@"\s*,\s*").Split(includes);
            }
            if(orderBys != null)
            {
                collectionOrderBy = new Regex(@"\s*,\s*").Split(orderBys);
            }
            var query = CreateQuery(skip , top , q , collectionInclude , collectionOrderBy);

            return new DataManagerResponse
            {
                Method = MethodRequest.GET,
                StatusCode = 200,
                Message = null,
                Result = query.ToList()
            };
        }


        private IQueryable<DoiTac> CreateQuery(int skip , int top ,  string search , ICollection<string> include , ICollection<string> orderBy)
        {
            var query = _dbContext.DoiTacs.AsQueryable();

            query = query.Skip(skip).Take(top); 

            if(include != null && include.Count() > 0)
            {
                foreach(var item in include)
                {
                    query = query.Include(item);
                }
            }
            
            if(orderBy != null)
            {
                foreach(var item in orderBy)
                {
                    string[] contain = item.Split('|');
                    if(contain.Length == 1)
                    {
                        contain = new string[2] { contain[0] , "ASC"};
                    }                    
                    switch (contain[1])
                    {
                        case "DESC":
                            query = OrderByDescending(query, contain[0]);
                            break;
                        default:
                            query = OrderBy(query, contain[0]);
                            break;
                    }
                }
            }
            
            if(search != null)
            {
                query = query.Where(item => item.CMT.Contains(search));
            }
            return query.AsQueryable();
        }
        
    }
}
