using Mango.Web.Models;
using Mango.Web.Models.DTO;
using Mango.Web.Service.IService;

namespace Mango.Web.Service
{
    public class CartService : BaseService, ICartService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CartService(IHttpClientFactory clientFactory) : base(clientFactory) { }

        public async Task<T> AddToCartAsync<T>(CartDTO cartDTO, string token = null)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartAPIBase + "/api/cart",
                AccessToken = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType= SD.ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/cart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ShoppingCartAPIBase + "/api/cart/" + cartId,
                AccessToken = token
            });
        }

        public async Task<T> UpdateCartAsync<T>(CartDTO cartDTO, string token = null)
        {
            return await this.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = cartDTO,
                Url = SD.ProductAPIBase + "/api/cart",
                AccessToken = token
            });
        }
    }
}
