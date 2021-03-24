using System.Threading.Tasks;
using view_model.Catalog.Products;
using view_model.Common;

namespace application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}
