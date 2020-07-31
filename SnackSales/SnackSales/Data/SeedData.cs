using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SnackSales.Data
{
    public static class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roleNames = {"Admin", "Member"};

            foreach (string roleName in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(roleName).ConfigureAwait(false);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName)).ConfigureAwait(false);
                }
            }

            var powerUser = new IdentityUser
            {
                UserName = configuration.GetSection("UserSettings")["UserName"],
                Email = configuration.GetSection("UserSettings")["UserEmail"]
            };

            string userPassword = configuration.GetSection("UserSettings")["UserPassword"];

            var user = await userManager.FindByEmailAsync(powerUser.Email).ConfigureAwait(false);

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(powerUser, userPassword).ConfigureAwait(false);
                if (createPowerUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}