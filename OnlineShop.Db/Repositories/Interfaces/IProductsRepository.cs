using Microsoft.AspNetCore.Http;
using OnlineShop.Db.Models;

namespace OnlineShop.Db.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> TryGetByIdAsync(Guid productId);

        Task AddAsync(Product product);

        Task EditAsync(Product product, IFormFile[] uploadedFiles);

        Task RemoveAsync(Guid productId);
    }
}
