using Electronic_Web_App.Models;

namespace Electronic_Web_App.Repository.CartRepository
{
    public interface ICartRepository
    {
        void AddToCart(Cart cart);
        List<Cart> GetAllCarts();
        List<Cart> GetUserCarts(string UserId);
        Cart GetCartById(int cartId);
        void RemoveFromCart(int cartId);
        int Save();
        void Update(Cart cart);
    }
}