using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<List<Product>> GetAllAsync(string userId);

        Task AddAsync(string userId, Product product);

        Task RemoveAsync(string userId, Guid productId);

        Task ClearAsync(string userId);
    }
}
