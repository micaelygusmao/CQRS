using GerenciaEstoqueCQRS.Model;
using GerenciaEstoqueCQRS.Model.Entity;
using GerenciaEstoqueCQRS.Repository;
using MediatR;

namespace GerenciaEstoqueCQRS.Command.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Name = request.Name, Price = request.Price };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
