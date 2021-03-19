using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class KhachHangRepository : RepositoryBase<KhachHang> , IKhachHangRepository
    {
        public KhachHangRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
