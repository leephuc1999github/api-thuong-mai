using library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using view_model.Common;
using view_model.System.Languages;

namespace application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly EShopDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public LanguageService(EShopDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public async Task<ApiResult<List<LanguageVm>>> GetAll()
        {
            var languages = await _dbContext.Languages.Select(x => new LanguageVm()
            {
                Id = x.Id,
                Name = x.Name,
                Icon = x.Icon,
                IsDefault = x.IsDefault
            }).ToListAsync();
            return new ApiSuccessResult<List<LanguageVm>>(languages);
        }
    }
}
