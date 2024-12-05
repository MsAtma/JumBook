using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repositories.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    [Authorize] 

    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;
		private readonly IMapper mapper;

		public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuyAsync(UserDeliveryInfoViewModel userViewModel)
        {
			if (!ModelState.IsValid)
			{
				return View(nameof(Index), userViewModel);
			}
			var existingCart = await cartsRepository.TryGetByUserIdAsync(User.Identity.Name);			
			var order = new Order
            {
                User = mapper.Map<UserDeliveryInfo>(userViewModel),
                Items = existingCart.Items
            };			
			await ordersRepository.AddAsync(order);
            await cartsRepository.ClearAsync(User.Identity.Name);
			var model = mapper.Map<OrderViewModel>(order);
			return View(model);			
        }
    }
}