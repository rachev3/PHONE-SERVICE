using Microsoft.AspNetCore.Identity;
using PHONE_SERVICE.Data.DTO;

namespace PHONE_SERVICE.Data.Seeders
{
    public class RolesSeeder
    {
        public static async Task Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Worker", "Client" };

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

            var adminUser = new User
            {
                FirstName = "Admin",
                LastName = "Adminov",
                Address = "PMG",
                UserName = "admin@example.com",
                Email = "admin@example.com",

            };
            var workerUser = new User
            {
                FirstName = "Worker",
                LastName = "Workerov",
                Address = "PMG",
                UserName = "worker@example.com",
                Email = "worker@example.com",

            };
            var clientUser = new User
            {
                FirstName = "Client",
                LastName = "Client",
                Address = "PMG",
                UserName = "client@example.com",
                Email = "client@example.com",

            };

            string adminPassword = "Admin@123";
            string workerPassword = "Worker@123";
            string clientPassword = "Client@123";

            var admin = await userManager.FindByEmailAsync("admin@example.com");
            var worker = await userManager.FindByEmailAsync("worker@example.com");
            var client = await userManager.FindByEmailAsync("client@example.com");
            
            if (admin == null)
            {
                var createPowerUser = await userManager.CreateAsync(adminUser, adminPassword);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
            if (worker == null)
            {
                var createWorkerUser = await userManager.CreateAsync(workerUser, workerPassword);
                if (createWorkerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(workerUser, "Worker");
                }
            }
            if (client == null)
            {
                var createClientUser = await userManager.CreateAsync(clientUser, clientPassword);
                if (createClientUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(clientUser, "Client");
                }
            }
        }
    }
}
