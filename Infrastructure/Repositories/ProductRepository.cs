using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.ViewModel.Products;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly MiniECommerceDbContext _context;

        public ProductRepository(MiniECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(ProductVM productVM)
        {
            var product = new Product()
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price,
                Quantity = productVM.Quantity
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<ProductVM>> GetAllProductsAsync()
        {
            var products = await (from p in _context.Products
                                  select new ProductVM()
                                  {
                                      Id = p.Id,
                                      Name = p.Name,
                                      Description = p.Description,
                                      Price = p.Price,
                                      Quantity = p.Quantity
                                  }).ToListAsync();
            return products;
        }

        public async Task<ProductVM> GetProductById(int Id)
        {
            var product = await (from p in _context.Products
                                 where Id == p.Id
                                 select new ProductVM()
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Description = p.Description,
                                     Price = p.Price,
                                     Quantity = p.Quantity
                                 }).FirstOrDefaultAsync();
            if (product == null)
                throw new NotFoundException($"Product with ID {Id} not found");
            return product;
        }
    }


}