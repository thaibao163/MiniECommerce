using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IProductRepository _productRepository;

        //Inject vào BaseController
        public BaseController(IMediator mediator, IProductRepository productRepository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        protected IMediator Mediator => _mediator;
    }
}