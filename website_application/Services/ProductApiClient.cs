using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using view_model.Catalog.Products;
using view_model.Common;

namespace admin_webapp.Services
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductApiClient(IHttpClientFactory httpClientFactory , IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5000");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync("api/products/paging?" + 
                $"pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}&categoryId={request.CategoryId}&languageId={request.LanguageId}");
            var body = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<PagedResult<ProductVm>>(body);
            return products;
        }
    }
}
