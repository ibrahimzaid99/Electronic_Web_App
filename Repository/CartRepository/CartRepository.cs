using Electronic_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Electronic_Web_App.Repository.CartRepository
{
    public class CartRepository : ICartRepository
    {


        MVC_Project_Context context;

        public CartRepository(MVC_Project_Context _context)
        {
            context = _context;
        }

        public List<Cart> GetAllCarts()
        {

            return context.Carts.Include(c => c.Products).ToList();


        }
        public List<Cart> GetUserCarts(string UserId)
        {

            return context.Carts.Include(c => c.Products).Where(cart => cart.UserId == UserId).ToList();


        }
        //------------------------------------
        public Cart GetCartById(int cartId)
        {

            return context.Carts.FirstOrDefault(cart=> cart.Id == cartId);
        }

        //------------------------------------
        public void Update(Cart cart)
        {
            context.Update(cart);
            context.SaveChanges();
        }
        //------------------------------------
        public void RemoveFromCart(int cartId)
        {
            var cart = context.Carts.Find(cartId);
            if (cart != null)
            {
                context.Carts.Remove(cart);
            }
        }
        //------------------------------------
        public void AddToCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }
        //------------------------------------
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}