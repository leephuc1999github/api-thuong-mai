using application.Catalog.Dtos;
using application.Catalog.Products.Dtos;
using application.Catalog.Products.Dtos.Public;
using System.Threading.Tasks;

namespace application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
