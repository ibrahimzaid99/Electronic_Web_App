
using Electronic_Web_App.Models;
using Electronic_Web_App.Repository.CartRepository;
using Electronic_Web_App.Repository.ProductsRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Electronic_Web_App.Models.Authontication;

namespace Electronic_Web_App.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository cartRepository;
        private readonly IProductsRepository productsRepository;
        private readonly UserManager<ApplicationIdentityUser> UserManager;

        public CartController(ICartRepository cartRepository, IProductsRepository productsRepository, UserManager<ApplicationIdentityUser> UserManager)
        {
            this.cartRepository = cartRepository;
            this.productsRepository = productsRepository;
            this.UserManager = UserManager;
        }

        public async Task<IActionResult> Index()
        {

            ApplicationIdentityUser user = await UserManager.GetUserAsync(User);

            var carts = cartRepository.GetUserCarts(user.Id);
            return View(carts);
        }

        public async Task<IActionResult> AddToCart(int id)
        {

            ApplicationIdentityUser user = await UserManager.GetUserAsync(User);
            Cart CartItem = new Cart()
            {
                Product_Id = id,
                UserId = user.Id,
                Amount = 1
            };
           cartRepository.AddToCart(CartItem);
            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Cart c1 = cartRepository.GetCartById(id);
            c1.Amount += 1;
            cartRepository.Save();
            return RedirectToAction("index");


        }
        public IActionResult lost(int id)
        {
            Cart c1 = cartRepository.GetCartById(id);
            if (c1.Amount > 0)
            {
                c1.Amount -= 1;
            }
            if (c1.Amount == 0)
            {
                cartRepository.RemoveFromCart(id);
            }
            cartRepository.Save();
            return RedirectToAction("index");

        }
        public IActionResult delete(int id)
        {
            cartRepository.RemoveFromCart(id);
            cartRepository.Save();
            return RedirectToAction("index");
        }
    }
}
