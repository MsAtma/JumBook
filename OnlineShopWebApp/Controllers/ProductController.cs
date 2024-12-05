using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
		private readonly IProductsRepository productsRepository;
		private readonly IMapper mapper;

		public ProductController(IProductsRepository productsRepository, IMapper mapper)
		{
			this.productsRepository = productsRepository;
			this.mapper = mapper;
		}

		public async Task<IActionResult> Index(Guid productId)
		{
            var product = await productsRepository.TryGetByIdAsync(productId);
			var model = mapper.Map<ProductViewModel>(product);
			return View(model);
		}        
    }
}