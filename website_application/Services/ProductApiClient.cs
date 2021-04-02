using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public ProductApiClient(IHttpClientFactory httpClientFactory , IHttpContextAccessor httpContextAccessor , IConfiguration configuration) 
        {
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public async Task<ApiResult<PagedResult<ProductVm>>> GetPagings(GetManageProductPagingRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["DomainString"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.GetAsync("api/products/paging?" + 
                $"pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}&categoryId={request.CategoryId}&languageId={request.LanguageId}");
            var body = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<ApiResult<PagedResult<ProductVm>>>(body);
            return products;
        }
    }
}
