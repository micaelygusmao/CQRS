using GerenciaEstoqueCQRS.Model.ViewModel;
using MediatR;

namespace GerenciaEstoqueCQRS.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
    }
}
