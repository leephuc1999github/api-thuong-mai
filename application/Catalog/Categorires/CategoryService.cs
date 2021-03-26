using library.Data;
using library.Models.ESHOP;
using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Catalog.Categories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace application.Catalog.Categorires
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopDbContext _dbContext;
        public CategoryService(EShopDbContext dbContext){
            _dbContext = dbContext;
        }
        public async Task<List<CategoryVm>> GetAll(string languageId)
        {
            var query = from c in _dbContext.Categories
                        join ct in _dbContext.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();
        }

        public async Task<CategoryVm> GetById(string languageId, int id)
        {
            var query = from c in _dbContext.Categories
                        join ct in _dbContext.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryVm()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId
            }).FirstOrDefaultAsync();
        }
    }
}
