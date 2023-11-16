using Electronic_Web_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Electronic_Web_App.Repository.ProductsRepository
{
    public class ProductsRepository : IProductsRepository
    {

         
        MVC_Project_Context context;

        public ProductsRepository(MVC_Project_Context _Context)
        {
            context = _Context;
        }
        public List<Products> GetAll()
        {
            return context.Products.Include(c => c.Categories).ToList();
        }

        //------------------------------------
        public Products GetProductById(int id)
        {
            return context.Products.FirstOrDefault(c => c.Id == id);
        }
        //------------------------------------
        public void Update(Products products)
        {
            context.Update(products);
        }
        //------------------------------------
        public void Delete(int id)
        {
            Products OrginalProducts = GetProductById(id);
            context.Remove(OrginalProducts);
        }
        //------------------------------------
        public void Insert(Products product)
        {
            context.Products.Add(product);
        }
        //------------------------------------
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
