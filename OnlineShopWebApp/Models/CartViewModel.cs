namespace OnlineShopWebApp.Models
{
    public class CartViewModel
    {
        public string? UserId { get; set; }

        public List<CartItemViewModel>? Items { get; set; }

        public decimal Amount
        {
            get
            {
                return Items?.Sum(item => item.Amount) ?? 0;
            }
        }

        public int Quantity
        {
            get
            {
                return Items?.Sum(item => item.Quantity) ?? 0;
            }
        }
    }
}
