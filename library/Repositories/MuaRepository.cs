using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class MuaRepository : RepositoryBase<Mua> , IMuaRepository
    {
        public MuaRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
