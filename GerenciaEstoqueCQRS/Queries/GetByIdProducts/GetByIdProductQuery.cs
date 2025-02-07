using GerenciaEstoqueCQRS.Model.ViewModel;
using MediatR;

namespace GerenciaEstoqueCQRS.Queries.GetByIdProducts
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductViewModel?>;

}
