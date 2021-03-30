using admin_webapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using view_model.Catalog.Products;

namespace admin_webapp.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        public ProductController(IProductApiClient productApiClient,ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword , int pageIndex = 1, int pageSize = 10 , int? categoryId = null)
        {
            var languageId = "en-US";
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                CategoryId = categoryId,
                LanguageId = languageId
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

            var categories = await _categoryApiClient.GetAll(languageId);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);        
        }
    }
}
