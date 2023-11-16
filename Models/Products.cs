using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Electronic_Web_App.Models
{
    public class Products
    {
      public int Id { get; set; }

        [Required(ErrorMessage ="You Didn't Entry A Title To This Product")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You Didn't Entry A Price To This Product")]
        public int Price { get; set; }

        [Required(ErrorMessage = "You Didn't Entry A Description To This Product")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You Didn't Entry An Image To This Product")] 
        [RegularExpression(@"^\w+\.(png|jpg)$", ErrorMessage = "Image Must Be (png or Jpg)")]
        public string ImgUrl { get; set; }
        [Required(ErrorMessage = "You Didn't Entry An Rating To This Product")]
        [Range(minimum:0, maximum: 5 ,ErrorMessage ="Range Must Be Between(0=>5)")]
        public int Rating { get; set; }

        [ForeignKey("Categories")]
         public int Category_id { get; set; }
         public Categories? Categories { get; set; }
        public List<Cart>? carts { get; set; }


    }
}
