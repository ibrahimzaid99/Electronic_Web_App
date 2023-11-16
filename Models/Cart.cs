using Electronic_Web_App.Models.Authontication;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electronic_Web_App.Models
{
    public class Cart
    {
        public int Id { get; set; }

        //------------------------------

        [ForeignKey("Products")]
        public int? Product_Id { get; set; }
        public virtual Products? Products { get; set; }

        //------------------------------

        [ForeignKey("ApplictionIdentityUser")]
        public string ? UserId { get; set; }

        public virtual ApplicationIdentityUser? User { get; set; }
        //------------------------------

        public int Amount { get; set; }

        //------------------------------


    }
}
