using Application.Features.Products.Commands;
using Application.Features.Products.Queries;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, IProductRepository productRepository) : base(mediator, productRepository)
        {
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProduct request)
        {
            if (request == null)
            {
                return BadRequest("Request null");
            }
            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductById { Id = id }));
        }

        /// <summary>
        /// Update Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, UpdateProduct request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(request));
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <returns></returns>
        [HttpGet("product")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await Mediator.Send(new GetAllProducts()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await Mediator.Send(new GetProductById { Id = id }));
        }
    }
}