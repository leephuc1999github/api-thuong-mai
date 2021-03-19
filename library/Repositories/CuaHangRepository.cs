using api.Models;
using library.Interfaces;
using library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace library.Repositories
{
    public class CuaHangRepository : RepositoryBase<CuaHang> , ICuaHangRepository
    {
        public CuaHangRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
