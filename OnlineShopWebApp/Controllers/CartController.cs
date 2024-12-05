using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize] 
    public class CartController : Controller
    {
        private readonly IProductsRepository productRepository; 
        private readonly ICartsRepository cartsRepository; 
        private readonly IMapper mapper; 

        public CartController(IProductsRepository productRepository, ICartsRepository cartsRepository, IMapper mapper)
        {
            this.productRepository = productRepository; 
            this.cartsRepository = cartsRepository; 
            this.mapper = mapper; 
        }

        public async Task<IActionResult> Index()
        {
            var cart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name); 
            var model = mapper.Map<CartViewModel>(cart); 
            return View(model); 
        }

        public async Task<IActionResult> AddAsync(Guid productId)
        {
            var product = await productRepository.TryGetByIdAsync(productId); 
            await cartsRepository.AddAsync(product, User.Identity.Name); 
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DecreaseAmountAsync(Guid productId)
        {
            var product = await productRepository.TryGetByIdAsync(productId); 
            await cartsRepository.DecreaseAmountAsync(product, User.Identity.Name); 
            return RedirectToAction(nameof(Index)); 
        }

        public async Task<IActionResult> ClearAsync()
        {
            await cartsRepository.ClearAsync(User.Identity.Name); 
            return RedirectToAction(nameof(Index)); 
        }
    }
}
