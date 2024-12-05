using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface ICartsRepository
    {
        Task<Cart> TryGetByUserIdAsync(string? userId);

        Task AddAsync(Product product, string userId);

        Task DecreaseAmountAsync(Product product, string userId);

        Task ClearAsync(string? userId);
    }
}
