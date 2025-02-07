using MediatR;

namespace GerenciaEstoqueCQRS.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductCommand(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}