using api.Models;
using library.Repositories;

namespace library.Interfaces
{
    public class GiamSatRepository : RepositoryBase<GiamSat> , IGiamSatRepository
    {
        public GiamSatRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
