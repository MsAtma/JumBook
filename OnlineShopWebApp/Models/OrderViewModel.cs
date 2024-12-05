namespace OnlineShopWebApp.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public UserDeliveryInfoViewModel? User { get; set; }

        public List<CartItemViewModel>? Items { get; set; }

        public DateTime CreateDateTime { get; set; }

        public OrderStatusViewModel Status { get; set; }

        public decimal? Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount);
            }
        }

        public OrderViewModel()
        {
            CreateDateTime = DateTime.Now;

            Status = OrderStatusViewModel.Created;
        }
    }
}
