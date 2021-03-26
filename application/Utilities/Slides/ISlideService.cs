using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Utilities.Slides;

namespace application.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}
