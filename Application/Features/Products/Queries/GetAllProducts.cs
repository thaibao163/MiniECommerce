using Application.Interfaces.Repositories;
using Domain.ViewModel.Products;
using MediatR;

namespace Application.Features.Products.Queries
{
    public class GetAllProducts : IRequest<IEnumerable<ProductVM>>
    {
        public class GetAllProductsHandler : IRequestHandler<GetAllProducts, IEnumerable<ProductVM>>
        {
            private readonly IProductRepository _productRepository;
            public GetAllProductsHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<IEnumerable<ProductVM>> Handle(GetAllProducts request, CancellationToken cancellationToken)
            {
                var productList = await _productRepository.GetAllProductsAsync();
                return productList;
            }
        }
    }
}