using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Введіть коректний Email")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль повинен містити від 8 до 200 символів")]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
