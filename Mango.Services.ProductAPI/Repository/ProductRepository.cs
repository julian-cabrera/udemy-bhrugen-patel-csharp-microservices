using AutoMapper;
using Mango.Services.ProductAPI.DbContexts;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDTO> CreateUpdateProduct(ProductDTO dto)
        {
            Product product = _mapper.Map<ProductDTO, Product>(dto);

            if(product.ProductId > 0)
            {
                _context.Products.Update(product);
            } else
            {
                _context.Products.Add(product);
            }
            await _context.SaveChangesAsync();

            return _mapper.Map<Product, ProductDTO>(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                
                if(product == null) 
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            Product product = await _context.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            IEnumerable<Product> productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(productList);
        }
    }
}
