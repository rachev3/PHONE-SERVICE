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


        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(UserPageViewModel model)
        {
            var users = await userManager.Users.ToListAsync();

            if (model.Username != null) users = users.Where(u => u.UserName.Contains(model.Username)).ToList();
            if (model.FirstName != null) users = users.Where(u => u.FirstName.Contains(model.FirstName)).ToList();
            if (model.LastName != null) users = users.Where(u => u.LastName.Contains(model.LastName)).ToList();

            if (model.Role != null)
            {
                var usersToKeep = new List<User>();
                foreach (var user in users)
                {
                    var userRole = await userManager.GetRolesAsync(user);
                    if (userRole.Contains(model.Role))
                    {
                        usersToKeep.Add(user);
                    }
                }
                users = usersToKeep;
            }

            var pageViewModel = new UserPageViewModel();
            foreach (var user in users)
            {
                var userRoles = await userManager.GetRolesAsync(user);
                pageViewModel.Users.Add(new UserViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Role = userRoles[0]
                });
            }

            return View("Dashboard", pageViewModel);
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

                ModelState.AddModelError(string.Empty, "Невалиден опит за влизане.");
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
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Promote(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, "Client");
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
