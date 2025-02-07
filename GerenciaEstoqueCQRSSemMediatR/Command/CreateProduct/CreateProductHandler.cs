using GerenciaEstoqueCQRSSemMediatR.Model;
using GerenciaEstoqueCQRSSemMediatR.Model.Entity;
using GerenciaEstoqueCQRSSemMediatR.Repository;

namespace GerenciaEstoqueCQRSSemMediatR.Command.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly ApplicationDbContext _context;

        public CreateProductHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request)
        {
            var product = new Product { Name = request.Name, Price = request.Price };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
