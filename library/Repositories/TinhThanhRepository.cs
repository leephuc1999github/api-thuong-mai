using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class TinhThanhRepository : RepositoryBase<TinhThanh> , ITinhThanhRepository
    {
        public TinhThanhRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
