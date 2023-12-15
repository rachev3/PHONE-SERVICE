using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PHONE_SERVICE.Data.DTO;
using PHONE_SERVICE.Models.UserModels;

namespace PHONE_SERVICE.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            User newUser = new(model);

            var user = await userManager.FindByEmailAsync(model.Email) ?? await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                var createUser = await userManager.CreateAsync(newUser, model.Password);
                if (createUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(newUser, "Client");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Dashboard()
        {
            var usersWithRoles = new UserPageViewModel();

            foreach (var user in await userManager.Users.ToListAsync())
            {
                var userRoles = await userManager.GetRolesAsync(user);
                usersWithRoles.Users.Add(new UserViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = userRoles[0]
                });
            }
            return View(usersWithRoles);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Promote(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user,"Client");
            await userManager.AddToRoleAsync(user, "Worker");
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Demote(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, "Worker");
            await userManager.AddToRoleAsync(user, "Client");
            return RedirectToAction("Dashboard");
        }
    }
}
