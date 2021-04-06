using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Catalog.ProductImages;
using view_model.Catalog.Products;
using view_model.Common;

namespace application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId , int addedQuantity);
        Task AddViewCount(int productId);
        Task<ProductVm> GetById(int productId, string languageId);
        Task<PagedResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);
        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}
