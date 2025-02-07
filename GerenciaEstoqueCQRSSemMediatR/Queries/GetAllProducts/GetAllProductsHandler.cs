using GerenciaEstoqueCQRSSemMediatR.Model.Entity;
using GerenciaEstoqueCQRSSemMediatR.Model.ViewModel;
using GerenciaEstoqueCQRSSemMediatR.Repository;
using Microsoft.EntityFrameworkCore;

namespace GerenciaEstoqueCQRSSemMediatR.Queries.GetAllProducts
{
    public class GetAllProductsHandler
    {
        private readonly QueryDbContext _context;

        public GetAllProductsHandler(QueryDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request)
        {
            List<Product> products = await _context.Products.ToListAsync();

            return products.Select(prod => new ProductViewModel(prod.Name, prod.Price)).ToList();  
        }
    }
}
