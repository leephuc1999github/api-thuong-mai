using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Catalog.Categories;

namespace application.Catalog.Categorires
{
    public interface ICategoryService 
    {
        Task<List<CategoryVm>> GetAll(string languageId);

        Task<CategoryVm> GetById(string languageId, int id);
    }
}
