namespace OnlineShop.Db.Models
{
    public class UserDeliveryInfo
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Patronymic { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? DeliveryAddress { get; set; }

        public string? PaymentMethod { get; set; }
    }
}
