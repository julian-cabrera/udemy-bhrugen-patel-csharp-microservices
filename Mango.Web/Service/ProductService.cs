using Mango.Web.Models;
using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<T> CreateProductAsync<T>(ProductDTO productDTO, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = productDTO,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> DeleteProductAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> GetAllProductsAsync<T>(string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int id, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/products/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDTO productDTO, string token)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDTO,
                Url = SD.ProductAPIBase + "/api/products",
                AccessToken = token
            });
        }
    }
}
