﻿using admin_webapp.Services;
using admin_webapp.Services.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using view_model.Catalog.Categories;
using view_model.Catalog.Products;
using view_model.Common;

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
        #region all product
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
            var categories = await _categoryApiClient.GetAll(languageId);
            List<SelectListItem> optionsCategory = new List<SelectListItem>();
            foreach(var category in categories)
            {
                SelectListItem option = new SelectListItem()
                {
                    Text = category.Name,
                    Value = category.Id + ""
                };
                optionsCategory.Add(option);
            }
            ViewData["OptionsCategory"] = optionsCategory;
            ViewBag.categoryId = categoryId;
            ViewBag.keyword = keyword;
            return View(data);
        }
        #endregion

        #region create product
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
        #endregion

        #region edit product
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
        #endregion

        #region delete product
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productApiClient.DeleteProduct(id);
            if (result)
            {
                TempData["success"] = "true";
                return RedirectToAction("Index");
            }
            TempData["success"] = "false";
            return RedirectToAction("Index");
        }
        #endregion

        #region assign category
        [HttpGet]
        public async Task<IActionResult> CategoryAssign(int id)
        {
            var categories = await GetCategoryAssignRequest(id);
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAssign(CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _productApiClient.CategoryAssign(request.Id, request);

            if (result.IsSuccessed)
            {
                TempData["success"] = "true";
                return RedirectToAction("Index");
            }
            TempData["success"] = "false";
            ModelState.AddModelError("", result.Message);
            var roleAssignRequest = await GetCategoryAssignRequest(request.Id);

            return View(roleAssignRequest);
        }
        #endregion

        private async Task<CategoryAssignRequest> GetCategoryAssignRequest(int id)
        {
            var languageId = HttpContext.Session.GetString("DefaultLanguageId");
            var product = await _productApiClient.GetById(id , languageId);
            var categories = await _categoryApiClient.GetAll(languageId);
            var result = new CategoryAssignRequest();
            foreach (var item in categories)
            {
                result.Categories.Add(new SelectItem() { Id = item.Id + "" , Name = item.Name , Selected = product.Categories.Contains(item.Name) });
            }
            return result;
        }
    }
}
