using Electronic_Web_App.Models;

namespace Electronic_Web_App.Repository.CategoriesRepository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        
        MVC_Project_Context context;

        public CategoriesRepository(MVC_Project_Context _context)
        {
            context = _context;
        }
        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        //------------------------------------
        public Categories GetCategoryById(int id)
        {

            return context.Categories.FirstOrDefault(e => e.Id == id);
        }
        //------------------------------------
        public void Update(Categories categories)
        {
            context.Update(categories);
        }
        //------------------------------------
        public void Delete(int id)
        {
            Categories OrginalCategories = GetCategoryById(id);
            context.Remove(OrginalCategories);
        }
        //------------------------------------
        public void Insert(Categories category)
        {
            context.Categories.Add(category);
        }
        //------------------------------------
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
