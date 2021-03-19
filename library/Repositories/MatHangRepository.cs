using api.Models;
using library.Interfaces;

namespace library.Repositories
{
    public class MatHangRepository : RepositoryBase<MatHang> , IMatHangRepository
    {
        public MatHangRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
