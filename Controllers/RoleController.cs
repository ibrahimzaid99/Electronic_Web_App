using Electronic_Web_App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Electronic_Web_App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)

        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewRole(RoleNameViewModel Rolevm)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = Rolevm.RoleName;

                IdentityResult result = await roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("NewRole", "Role");
                }
                foreach (var items in result.Errors)
                {
                    ModelState.AddModelError("", items.Description);
                }
            }
            return View(Rolevm);
        }
    }

}
