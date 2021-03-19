using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class NhanVienQuanLyRepository : RepositoryBase<NhanVienQuanLy> , INhanVienQuanLyRepository
    {
        public NhanVienQuanLyRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
