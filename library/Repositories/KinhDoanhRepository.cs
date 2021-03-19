using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class KinhDoanhRepository : RepositoryBase<KinhDoanh> , IKinhDoanhRepository
    {
        public KinhDoanhRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
