using api.Models;
using library.Interfaces;
using library.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace library.Repositories
{
    public class HopDongRepository : RepositoryBase<HopDong> , IHopDongRepository
    {
        private AppDbContext _dbContext;
        public HopDongRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataManagerResponse> GetHopDongs(int skip = 0, int top = 100, string q = null, string includes = null)
        {
            ICollection<string> collectionInclude = null;
            if (includes != null)
            {
                collectionInclude = new Regex(@"\s*,\s*").Split(includes);
            }
            var query = CreateQuery(skip, top, q, collectionInclude);

            return new DataManagerResponse
            {
                Method = MethodRequest.GET,
                StatusCode = 200,
                Message = null,
                Result = query.ToList()
            };
        }

        private IQueryable<HopDong> CreateQuery(int skip, int top, string search, ICollection<string> include)
        {
            var query = _dbContext.HopDongs.AsQueryable();

            query = query.Skip(skip).Take(top);

            if (include != null && include.Count() > 0)
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            if (search != null)
            {
                query = query.Where(item => (item.ID + "," + item.NgayKyHopDong + "," + item.DoiTac.ToString() + "," + item.NhanVienDaiDien.ToString())
                                            .ToLower()
                                            .Contains(search.ToLower()));
            }
            return query.AsQueryable();
        }

    }
}
