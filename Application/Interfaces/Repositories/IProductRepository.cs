using Domain.Entities;
using Domain.ViewModel.Products;

namespace Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<ProductVM>> GetAllProductsAsync();
        Task<ProductVM> GetProductById(int id);
        Task<int> CreateAsync(ProductVM productVM);
    }
}