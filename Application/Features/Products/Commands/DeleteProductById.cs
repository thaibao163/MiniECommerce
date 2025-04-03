using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Products.Commands
{
    public class DeleteProductById : IRequest<string>
    {
        public int Id { get; set; }

        public class DeleteProductByIdHandler : IRequestHandler<DeleteProductById, string>
        {
            private readonly IProductRepository _productRepository;

            public DeleteProductByIdHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<string> Handle(DeleteProductById request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                if (product == null) return "Product not found";
                await _productRepository.DeleteAsync(product);
                await _productRepository.SaveAsync();
                return $"Delete success {product.Name}";
            }
        }
    }
}