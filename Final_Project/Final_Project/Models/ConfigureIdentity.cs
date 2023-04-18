using Microsoft.AspNetCore.Identity;

namespace Final_Project.Models
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
            string password = "1234";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            // if username doesn't exist, create it and add to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                Account user = new Account { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }

}
