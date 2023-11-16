using Microsoft.AspNetCore.Identity;

namespace Electronic_Web_App.Models.Authontication
{
    public class ApplicationIdentityUser:IdentityUser
    {

        public string Adress { get; set; }

        public int PhoneNumber { get; set; }

        public List<Cart>? carts { get; set; }
    }
}
