namespace OnlineShopWebApp.Models
{
    public class CartItemViewModel
    {
        public ProductViewModel? Product { get; set; }

        public int Quantity { get; set; }

        public decimal? Amount
        {
            get
            {
                return Product?.Cost * Quantity;
            }
        }
    }
}
