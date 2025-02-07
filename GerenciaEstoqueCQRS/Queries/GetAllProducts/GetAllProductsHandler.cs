using GerenciaEstoqueCQRS.Model.Entity;
using GerenciaEstoqueCQRS.Model.ViewModel;
using GerenciaEstoqueCQRS.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GerenciaEstoqueCQRS.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly QueryDbContext _context;

        public GetAllProductsHandler(QueryDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _context.Products.ToListAsync();

            return products.Select(prod => new ProductViewModel(prod.Name, prod.Price)).ToList();  
        }
    }
}
