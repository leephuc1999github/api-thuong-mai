using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class ChiNhanhRepository : RepositoryBase<ChiNhanh> , IChiNhanhRepository
    {
        public ChiNhanhRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
