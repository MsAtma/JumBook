using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfoViewModel
    {
        [Required(ErrorMessage = "Поле Ім'я повинно бути заповнене")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Ім'я повинно містити від 3 до 70 символів")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Поле Прізвище повинно бути заповнене")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Прізвище повинно містити від 3 до 70 символів")]
        public string? LastName { get; set; }

        [StringLength(70, MinimumLength = 3, ErrorMessage = "По батькові повинно містити від 3 до 70 символів")]
        public string? Patronymic { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Поле Телефон повинно бути заповнене")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Телефон повинен містити від 5 до 20 символів")]
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? PaymentMethod { get; set; }

        public string? UserIdentityName { get; set; }
    }
}
