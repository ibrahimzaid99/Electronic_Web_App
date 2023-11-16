using Electronic_Web_App.Models;
using Electronic_Web_App.Repository.CategoriesRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Electronic_Web_App.Controllers
{
    //[Authorize]
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {

        ICategoriesRepository categoriesRepository;
        public CategoriesController(ICategoriesRepository CategRepo)
        {
            categoriesRepository = CategRepo;
        }
        //[Authorize]
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Categories> categoriesModel = categoriesRepository.GetAll(); 
            return View("Index",categoriesModel);
        }

        [HttpGet]
        public IActionResult AddNewCategory()
        {
            return View("AddNewCategory");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewCategory(Categories NewCategory)
        {
            if (ModelState.IsValid==true)
            {
                categoriesRepository.Insert(NewCategory);
                categoriesRepository.Save();
                return RedirectToAction("Index");
            }
            return View("AddNewCategory",NewCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Categories Category = categoriesRepository.GetCategoryById(id);
            return View("Edit",Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit( Categories Category)
        {
            if (ModelState.IsValid == true)
            {
                categoriesRepository.Update(Category);
                categoriesRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Edit",Category);
        }

        public IActionResult Delete(int id)
        {
            Categories Category = categoriesRepository.GetCategoryById(id);
            categoriesRepository.Delete(Category.Id);
            categoriesRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
