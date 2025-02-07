namespace GerenciaEstoqueCQRSSemMediatR.Model.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel(string Name, decimal Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
