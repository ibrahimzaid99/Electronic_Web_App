using Electronic_Web_App.Models;

namespace Electronic_Web_App.Repository.ProductsRepository
{
    public interface IProductsRepository
    {
        void Delete(int id);
        List<Products> GetAll();
        Products GetProductById(int id);
        void Insert(Products product);
        int Save();
        void Update(Products products);
    }
}