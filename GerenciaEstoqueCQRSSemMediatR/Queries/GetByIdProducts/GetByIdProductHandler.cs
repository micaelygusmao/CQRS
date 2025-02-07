using GerenciaEstoqueCQRSSemMediatR.Model.Entity;
using GerenciaEstoqueCQRSSemMediatR.Model.ViewModel;
using GerenciaEstoqueCQRSSemMediatR.Repository;
using Microsoft.EntityFrameworkCore;

namespace GerenciaEstoqueCQRSSemMediatR.Queries.GetByIdProducts
{
    public class GetByIdProductHandler
    {
        private readonly QueryDbContext _context;

        public GetByIdProductHandler(QueryDbContext context)
        {
            _context = context;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == request.Id);

            if (product is not null)
                return new ProductViewModel(product.Name, product.Price);

            return null;
        }
    }
}
