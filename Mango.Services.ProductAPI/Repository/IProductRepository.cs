using Mango.Services.ProductAPI.Models.DTO;

namespace Mango.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        
        Task<ProductDTO> GetProductById(int id);

        Task<ProductDTO> CreateUpdateProduct(ProductDTO dto);

        Task<bool> DeleteProduct(int id);
    }
}
