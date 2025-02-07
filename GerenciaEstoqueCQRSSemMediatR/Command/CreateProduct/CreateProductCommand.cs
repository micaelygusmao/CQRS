

namespace GerenciaEstoqueCQRSSemMediatR.Command.CreateProduct
{
    public class CreateProductCommand
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