using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class CreateProduct : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public class CreateProductHandler : IRequestHandler<CreateProduct, int>
        {
            private readonly IProductRepository _productRepository;

            public CreateProductHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<int> Handle(CreateProduct request, CancellationToken cancellationToken)
            {
                var product = new Product()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Quantity = request.Quantity
                };
                await _productRepository.AddAsync(product);
                return product.Id;
            }
        }
    }
}