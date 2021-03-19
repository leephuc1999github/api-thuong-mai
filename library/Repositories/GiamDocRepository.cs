using api.Models;
using library.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace library.Interfaces
{
    public class GiamDocRepository : RepositoryBase<GiamDoc> , IGiamDocRepository
    {
        public GiamDocRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
