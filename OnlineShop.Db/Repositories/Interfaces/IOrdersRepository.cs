using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> TryGetByIdAsync(Guid orderId);

        Task AddAsync(Order order);

        Task UpdateStatusAsync(Guid orderId, OrderStatus newStatus);
    }
}
