using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize] 
    public class FavoriteController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoriteRepository favoriteRepository;
        private readonly IMapper mapper;

        public FavoriteController(IProductsRepository productsRepository, IFavoriteRepository favoriteRepository, IMapper mapper)
        {
            this.productsRepository = productsRepository;
            this.favoriteRepository = favoriteRepository;
            this.mapper = mapper;
        }

        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productsRepository.TryGetByIdAsync(productId);
            await favoriteRepository.AddAsync(User.Identity.Name, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveAsync(Guid productId)
        {
            await favoriteRepository.RemoveAsync(User.Identity.Name, productId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ClearAsync()
        {
            await favoriteRepository.ClearAsync(User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }
    }
}
