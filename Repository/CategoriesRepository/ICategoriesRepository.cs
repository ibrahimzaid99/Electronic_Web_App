using Electronic_Web_App.Models;

namespace Electronic_Web_App.Repository.CategoriesRepository
{
    public interface ICategoriesRepository
    {
        void Delete(int id);
        List<Categories> GetAll();
        Categories GetCategoryById(int id);
        void Insert(Categories category);
        int Save();
        void Update(Categories categories);
    }
}