using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Cart> TryGetByUserIdAsync(string? userId)
        {
            return await databaseContext.Carts
                .Include(x => x.Items) 
                .ThenInclude(x => x.Product) 
                .FirstOrDefaultAsync(cart => cart.UserId == userId); 
        }

        public async Task AddAsync(Product product, string? userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };

                newCart.Items = new List<CartItem>
                    {
                        new CartItem()
                        {
                            Quantity = 1,
                            Product = product
                        }
                    };
                databaseContext.Carts.Add(newCart); 
            }
            else
            {
                var existingCartItem = existingCart.Items
                    .FirstOrDefault(item => item.Product?.Id == product.Id);
                if (existingCartItem != null)
                {
                    existingCartItem.Quantity++;
                }
                else
                {
                    existingCart.Items.Add(new CartItem
                    {
                        Quantity = 1,
                        Product = product
                    });
                }
            }
            await databaseContext.SaveChangesAsync(); 
        }

        public async Task DecreaseAmountAsync(Product product, string userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            var existingCartItem = existingCart?.Items?
                .FirstOrDefault(item => item.Product?.Id == product.Id);
            if (existingCartItem == null)
            {
                return;
            }
            existingCartItem.Quantity--; 
            if (existingCartItem.Quantity == 0)
            {
                existingCart?.Items.Remove(existingCartItem);
            }
            if (existingCart?.Items.Count == 0)
            {
                databaseContext.Carts.Remove(existingCart);
            }
            await databaseContext.SaveChangesAsync(); 
        }

        public async Task ClearAsync(string? userId)
        {
            var existingCart = await TryGetByUserIdAsync(userId);
            databaseContext.Carts.Remove(existingCart);
            await databaseContext.SaveChangesAsync(); 
        }
    }
}
