using System.Threading.Tasks;
using view_model.Catalog.Products;
using view_model.Common;

namespace admin_webapp.Services
{
    public interface IProductApiClient
    {
        Task<ApiResult<PagedResult<ProductVm>>> GetPagings(GetManageProductPagingRequest request);
    }
}
