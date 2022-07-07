using Mango.Services.ProductAPI.Models.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _response = new ResponseDTO();
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                IEnumerable<ProductDTO> productDTOs = await _productRepository.GetProducts();
                _response.Result = productDTOs;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO> GetById(int id)
        {
            try
            {
                ProductDTO productDTO = await _productRepository.GetProductById(id);
                _response.Result = productDTO;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPost]
        public async Task<ResponseDTO> Post([FromBody] ProductDTO dto)
        {
            try
            {
                ProductDTO model = await _productRepository.CreateUpdateProduct(dto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize]
        [HttpPut]
        public async Task<ResponseDTO> Put([FromBody] ProductDTO dto)
        {
            try
            {
                ProductDTO model = await _productRepository.CreateUpdateProduct(dto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDTO> Delete(int id)
        {
            try
            {
                var success = await _productRepository.DeleteProduct(id);
                _response.Result = success;
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
