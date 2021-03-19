using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class NhanVienBaoVeRepository : RepositoryBase<NhanVienBaoVe> , INhanVienBaoVeRepository
    {
        public NhanVienBaoVeRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
