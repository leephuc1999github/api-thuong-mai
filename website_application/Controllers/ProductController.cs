using admin_webapp.Services;
using Microsoft.AspNetCore.Http;
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
        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
            _productApiClient = productApiClient;
        }
        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10, int? categoryId = null)
        {
            var languageId = HttpContext.Session.GetString("DefaultLanguageId");
            var request = new GetManageProductPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                CategoryId = categoryId,
                LanguageId = languageId
            };
            var data = await _productApiClient.GetPagings(request);
            //var categories = await _categoryApiClient.GetAll(languageId);

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await _productApiClient.CreateProduct(request);
            if (result)
            {
                TempData["success"] = "true";
                return RedirectToAction("Index");
            }
            TempData["success"] = "false";
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var languageId = HttpContext.Session.GetString("DefaultLanguageId");
            var result = await _productApiClient.GetById(id, languageId);
            var updateRequest = new ProductUpdateRequest()
            {
                Name = result.Name,
                Description = result.Description,
                Details = result.Details,
                LanguageId = languageId,
                SeoAlias = result.SeoAlias,
                SeoDescription = result.SeoDescription,
                SeoTitle = result.SeoTitle,
                Id = id
            };
            return View(updateRequest);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _productApiClient.UpdateProduct(request);
            if (result)
            {
                TempData["success"] = "true";
                return RedirectToAction("Index");
            }
            TempData["success"] = "false";
            ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
            return RedirectToAction("Index");
        }
    }
}
