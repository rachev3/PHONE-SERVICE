using Microsoft.AspNetCore.Identity;
using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Seeders
{
    public class RolesSeeder
    {
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Worker", "Client" }; // Add your desired roles

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // Create the roles and seed them to the database
                var roleExist = await roleManager.RoleExistsAsync(roleName);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a super user who will maintain the web app
            var poweruser = new User
            {
                FirstName = "Admin",
                LastName = "Adminov",
                Address = "PMG",
                UserName = "admin@example.com",
                Email = "admin@example.com",

            };

            string userPassword = "Admin@123";

            var user = await userManager.FindByEmailAsync("admin@example.com");

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // Assign the new user to the Admin role
                    await userManager.AddToRoleAsync(poweruser, "Admin");
                }
            }
        }
    }
}
