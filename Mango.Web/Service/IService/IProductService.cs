using Mango.Web.Models.DTO;

namespace Mango.Web.Service.IService
{
    public interface IProductService : IBaseService
    {
        Task<T> GetAllProductsAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductDTO productDTO, string token);
        Task<T> UpdateProductAsync<T>(ProductDTO productDTO, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
