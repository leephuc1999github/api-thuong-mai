using library.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using view_model.Utilities.Slides;

namespace application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly EShopDbContext _dbContext;

        public SlideService(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var slides = await _dbContext.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}
