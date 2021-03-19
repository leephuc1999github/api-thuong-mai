using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class NhanVienRepository : RepositoryBase<NhanVien> , INhanVienRepository
    {
        public NhanVienRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
