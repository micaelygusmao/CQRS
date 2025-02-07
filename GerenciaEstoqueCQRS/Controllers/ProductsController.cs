using GerenciaEstoqueCQRS.Command.CreateProduct;
using GerenciaEstoqueCQRS.Queries.GetAllProducts;
using GerenciaEstoqueCQRS.Queries.GetByIdProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaEstoqueCQRS.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id }, id);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return products != null ? Ok(products) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product != null ? Ok(product) : NotFound();
        }
    }

}
