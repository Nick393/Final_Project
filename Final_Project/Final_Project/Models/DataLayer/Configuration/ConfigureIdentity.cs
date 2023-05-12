using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models.DataLayer.Configuration
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(
        IServiceProvider provider)
        {
            var roleManager =
                provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager =
                provider.GetRequiredService<UserManager<Account>>();

            string username = "admin";
            string password = "Sesame";
            string roleName = "Admin";

            if (await roleManager.FindByIdAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            
            if (await userManager.FindByNameAsync(username) == null)
            {
                Account user = new Account { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
            string StudentName = "Student";
            string Studentpassword = "Sesame";
            string role = "Student";
            if (await roleManager.FindByIdAsync(role) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }


            if (await userManager.FindByNameAsync(StudentName) == null)
            {
                Account user = new Account { UserName = StudentName };
                var result = await userManager.CreateAsync(user, Studentpassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

        }
    }

}
