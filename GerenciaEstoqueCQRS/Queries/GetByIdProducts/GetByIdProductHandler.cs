using GerenciaEstoqueCQRS.Model.Entity;
using GerenciaEstoqueCQRS.Model.ViewModel;
using GerenciaEstoqueCQRS.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaEstoqueCQRS.Queries.GetByIdProducts
{
    public class GetByIdProductHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel?>
    {
        private readonly QueryDbContext _context;

        public GetByIdProductHandler(QueryDbContext context)
        {
            _context = context;
        }

        public async Task<ProductViewModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == request.Id);

            if (product is not null)
                return new ProductViewModel(product.Name, product.Price);

            return null;
        }
    }
}
