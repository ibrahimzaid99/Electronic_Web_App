
using Electronic_Web_App.Models.Authontication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Electronic_Web_App.Models
{
    public class MVC_Project_Context : IdentityDbContext<ApplicationIdentityUser>
    {
        public MVC_Project_Context():base()
        {
           
        }

        public MVC_Project_Context(DbContextOptions<MVC_Project_Context> options):base(options) 
        
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog =FinalMVCProject;Integrated Security=True;Encrypt=False");
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Orders> Orders { get; set; }
                
        public DbSet<Cart> Carts { get; set; }




    }
}
