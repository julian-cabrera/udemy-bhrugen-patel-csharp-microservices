using Mango.Services.ShoppingCartAPI.Models.DTO;
using Mango.Services.ShoppingCartAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        protected ResponseDTO _response;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _response = new ResponseDTO();
        }

        [HttpGet("{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDTO cartDTO = await _cartRepository.GetCartByUserId(userId);
                _response.Result = cartDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> AddCart([FromBody]CartDTO cartDTO)
        {
            try
            {
                var dto = await _cartRepository.CreateUpdateCart(cartDTO);
                _response.Result = dto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> UpdateCart([FromBody]CartDTO cartDTO)
        {
            try
            {
                var dto = await _cartRepository.CreateUpdateCart(cartDTO);
                _response.Result = dto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{cartId}")]
        public async Task<object> RemoveCart(int cartId)
        {
            try
            {
                var isSuccess = await _cartRepository.RemoveFromCart(cartId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
