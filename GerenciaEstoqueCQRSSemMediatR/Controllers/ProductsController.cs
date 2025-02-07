using GerenciaEstoqueCQRSSemMediatR.Command.CreateProduct;
using GerenciaEstoqueCQRSSemMediatR.Queries.GetAllProducts;
using GerenciaEstoqueCQRSSemMediatR.Queries.GetByIdProducts;
using Microsoft.AspNetCore.Mvc;

namespace GerenciaEstoqueCQRS.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {

        private readonly CreateProductHandler _createHandler;
        private readonly GetByIdProductHandler _getByIdHandler;
        private readonly GetAllProductsHandler _getAllHandler;

        public ProductsController(CreateProductHandler createHandler, GetByIdProductHandler getByIdHandler, GetAllProductsHandler getAllHandler)
        {
            _createHandler = createHandler;
            _getByIdHandler = getByIdHandler;
            _getAllHandler = getAllHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var id = await _createHandler.Handle(command);
            return CreatedAtAction(nameof(GetProductById), new { id }, id);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _getAllHandler.Handle(new GetAllProductsQuery());
            return products != null ? Ok(products) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _getByIdHandler.Handle(new GetProductByIdQuery(id));
            return product is not null ? Ok(product) : NotFound();
        }
    }

}
