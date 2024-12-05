using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using AutoMapper;
using OnlineShop.Db.Repositories.Interfaces;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl ?? "/Home" });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(login.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(login.ReturnUrl ?? "/Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Неправильная почта или пароль.");
            }
            return View(login);
        }

        // Регистрация
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = register.Email,
                    UserName = register.Email
                };

                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(register);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Orders()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

            var orders = await ordersRepository.GetAllAsync();
            var userOrders = orders.Where(o => o.User.Email == User.Identity.Name);
            var model = userOrders.Select(mapper.Map<OrderViewModel>).ToList();
            return View(model);
        }
    }
}
