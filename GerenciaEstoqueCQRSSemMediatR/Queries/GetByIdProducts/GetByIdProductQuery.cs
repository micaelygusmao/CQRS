using GerenciaEstoqueCQRSSemMediatR.Model.ViewModel;

namespace GerenciaEstoqueCQRSSemMediatR.Queries.GetByIdProducts
{
    public class GetProductByIdQuery
    {
        public GetProductByIdQuery(int Id)
        {
            Id = Id;
        }
        public int Id { get; set;}
    }

}
