using Application.Interfaces.Repositories;
using Domain.ViewModel.Products;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetProductById : IRequest<ProductVM>
    {
        public int Id { get; set; }
        public class GetProductByIdHandler : IRequestHandler<GetProductById, ProductVM>
        {
            private readonly IProductRepository _productRepository;
            public GetProductByIdHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<ProductVM> Handle(GetProductById request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetProductById(request.Id);
                return product;
            }
        }
    }
}