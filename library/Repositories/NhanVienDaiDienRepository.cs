using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class NhanVienDaiDienRepository : RepositoryBase<NhanVienDaiDien> , INhanVienDaiDienRepository
    {
        public NhanVienDaiDienRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
