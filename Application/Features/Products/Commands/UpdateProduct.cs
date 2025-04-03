using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class UpdateProduct : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public class UpdateProductHandler : IRequestHandler<UpdateProduct, string>
        {
            private readonly IProductRepository _productRepository;
            public UpdateProductHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<string> Handle(UpdateProduct request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                if (product == null) return "Product not found";
                else
                {
                    product.Name = request.Name;
                    product.Description = request.Description;
                    product.Price = request.Price;
                    product.Quantity = request.Quantity;
                }
                await _productRepository.UpdateAsync(product);
                return "Update success";
            }
        }





    }
}