using System.ComponentModel.DataAnnotations.Schema;

namespace Electronic_Web_App.Models
{
    public class Order_Items
    {
        public int Id { get; set; }
        //____________________________________
        public int Count { get; set; }
        //____________________________________
        public int Price { get; set; }
        //____________________________________

        [ForeignKey("Products")]
        public int Product_Id { get; set; }
        public Products? Products { get; set; }

        //____________________________________

        [ForeignKey("Orders")]
        public int Order_id { get; set; }
        public Orders? Orders { get; set; }

    }
}
