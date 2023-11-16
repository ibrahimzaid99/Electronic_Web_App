using Electronic_Web_App.Models;
using Electronic_Web_App.Repository.CategoriesRepository;
using Electronic_Web_App.Repository.ProductsRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Electronic_Web_App.Controllers
{
    //[Authorize]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        ICategoriesRepository categoriesRepository;
        IProductsRepository productsRepository;
        public ProductsController(ICategoriesRepository CategRepo, IProductsRepository ProdRepo)
        {
            productsRepository = ProdRepo;
            categoriesRepository = CategRepo;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Products> products = productsRepository.GetAll();
            return View("Index", products);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            List<Categories> CategoriesList = categoriesRepository.GetAll();
            ViewData["CategoriesList"] = CategoriesList;
            return View("AddNewProduct"); 

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNewProduct(Products NewProduct)
        {
            if (ModelState.IsValid==true) { 
           productsRepository.Insert(NewProduct);
           productsRepository.Save();
                return RedirectToAction("Index");
            }
            List<Categories> CategoriesList = categoriesRepository.GetAll();
            ViewData["CategoriesList"] = CategoriesList;
            return View("AddNewProduct", NewProduct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Products Product = productsRepository.GetProductById(id);
            List<Categories> CategoriesList = categoriesRepository.GetAll();
            ViewData["CategoriesList"] = CategoriesList;
            return View("Edit", Product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Products Product)
        {
             if (ModelState.IsValid == true)
            {
                productsRepository.Update(Product);
                productsRepository.Save();
                return RedirectToAction("Index");
            }
            List<Categories> CategoriesList = categoriesRepository.GetAll();
            ViewData["CategoriesList"] = CategoriesList;
           return View("Edit",Product);
        }

        public IActionResult Delete(int id)
        {
            if (id !=0) {
                Products Product = productsRepository.GetProductById(id);
                 productsRepository.Delete(Product.Id);
                productsRepository.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Category (string? id)
        {

            List<Products> Products = productsRepository.GetAll().Where(product => product.Categories.Name == id).ToList();
            return View(Products);
        }
    }
}
