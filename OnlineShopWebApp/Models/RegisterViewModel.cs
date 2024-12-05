using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не вказано електронну пошту")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Електронна пошта повинна містити від 2 до 200 символів")]
        [EmailAddress(ErrorMessage = "Введіть коректну електронну пошту")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Пароль повинен містити від 8 до 200 символів")]
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}
