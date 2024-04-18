using ECommerce.Data.Models.Identity;
using ECommerce.Data.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

      
        public IActionResult Register()
        {
            if (User.Identity.Name != null)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            var user = new AppUser()
            {
                Name = register.Name,
                Surname = register.Surname,
                UserName = register.UserName,
                Email = register.Email
            };
            var result = await _userManager.CreateAsync(user,register.Password);
            var roleExist = await _roleManager.RoleExistsAsync("Admin");
            AppRole role;
            if (!roleExist)
            {
                role = new AppRole("Admin");
                await _roleManager.CreateAsync(role);

            }
            else
                role = await _roleManager.FindByIdAsync("Admin");
            await _userManager.AddToRoleAsync(user, role.Name);
            
            if(result.Succeeded)
                return RedirectToAction("Login");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(register);

        }
    }
}
