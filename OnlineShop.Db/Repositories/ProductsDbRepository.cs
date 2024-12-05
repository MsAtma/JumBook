using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShop.Db.Repositories
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await databaseContext.Products.Include(x => x.Images).ToListAsync();
        }

        public async Task<Product> TryGetByIdAsync(Guid productId)
        {
            return await databaseContext.Products.Include(x => x.Images)
                .FirstOrDefaultAsync(product => product.Id == productId);
        }

        public async Task AddAsync(Product product)
        {
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync(); 
        }

        public async Task EditAsync(Product product, IFormFile[] uploadedFiles)
        {
            var currentProduct = await TryGetByIdAsync(product.Id);

            currentProduct.Name = product.Name;
            currentProduct.Cost = product.Cost;
            currentProduct.Description = product.Description;
            currentProduct.Categories = product.Categories;
            currentProduct.Author = product.Author;
            currentProduct.Publisher = product.Publisher;
            currentProduct.PublicationYear = product.PublicationYear;

            if (uploadedFiles != null)
            {
                foreach (var image in currentProduct.Images)
                {
                    databaseContext.Images.Remove(image);
                }

                foreach (var image in product.Images)
                {
                    image.ProductId = product.Id; 
                    databaseContext.Images.Add(image);
                }
            }

            await databaseContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid productId)
        {
            var product = await TryGetByIdAsync(productId);

            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync(); 
        }
    }
}
