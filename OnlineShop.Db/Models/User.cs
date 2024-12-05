using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Db.Models
{
    public class User : IdentityUser
    {
        public string? Email { get; set; }

        public string? PasswordHash { get; set; }
    }
}
