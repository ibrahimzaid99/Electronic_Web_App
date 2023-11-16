using Electronic_Web_App.Models.Authontication;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electronic_Web_App.Models
{
    public class Orders
    {
       public int Id { get; set; }

        public int Total_Price { get; set; }

        //=====================
        [ForeignKey("ApplicationIdentityUser")]
        public string? User_Id { get; set; }
        public virtual ApplicationIdentityUser? User { get; set; }
        //=======================
        public List<Order_Items>? Order_Items { get; set; }

    }
}
