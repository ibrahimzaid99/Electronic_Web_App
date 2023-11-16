using Electronic_Web_App.Models.Authontication;
using Electronic_Web_App.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Electronic_Web_App.Controllers
{
    public class AccountController : Controller
    {
        //registration 2actio 1 view
        private readonly UserManager<ApplicationIdentityUser> UserManager;
        private readonly SignInManager<ApplicationIdentityUser> SignInManager;

        public AccountController(UserManager<ApplicationIdentityUser>UserManager, SignInManager<ApplicationIdentityUser>SignInManager)
        {
            this.UserManager = UserManager;
            this.SignInManager = SignInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult>Register(RegisterUserViewModel UserViewModel)
        {
            if(ModelState.IsValid) 
            {
                ApplicationIdentityUser UserModel = new ApplicationIdentityUser();
                UserModel.UserName = UserViewModel.UserName;
                UserModel.Adress = UserViewModel.Address;
                UserModel.PhoneNumber = UserViewModel.PhoneNumber;
                UserModel.PasswordHash = UserViewModel.Password;
                IdentityResult result = await UserManager.CreateAsync(UserModel, UserViewModel.Password);
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(UserModel, false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(UserViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel UserViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationIdentityUser UserModel = await UserManager.FindByNameAsync(UserViewModel.UserName);
                if (UserModel != null)
                {
                    bool found = await UserManager.CheckPasswordAsync(UserModel, UserViewModel.Password);
                    if (found == true)
                    {
                        await SignInManager.SignInAsync(UserModel, UserViewModel.RememberMe);
                        bool isAdmin = await UserManager.IsInRoleAsync(UserModel, "Admin");
                        if(isAdmin)
                        {
                            return RedirectToAction("Index", "Categories");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Categories");
                        }
                        
                    }

                }

                ModelState.AddModelError("", "UserName Or Password Incorrect");

            }
            return View(UserViewModel);
        }


        public IActionResult SignOut()
        {
            SignInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel UserVm)
        {
            if (ModelState.IsValid)
            {
                var userModel = new ApplicationIdentityUser();
                userModel.UserName = UserVm.UserName;
                userModel.Email = UserVm.Email;
                userModel.PasswordHash = UserVm.Password;
                userModel.Adress = UserVm.Address;
                userModel.PhoneNumber = UserVm.PhoneNumber;

                IdentityResult result = await UserManager.CreateAsync(userModel, UserVm.Password);

                if (result.Succeeded == true)
                {
                    await UserManager.AddToRoleAsync(userModel,"Admin");
                    ////await UserManager.sin(userModel, false);
                    await SignInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index","Home");

                }
                else
                {
                    ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
                }


            }
            return View(UserVm);

        }

    }
}
