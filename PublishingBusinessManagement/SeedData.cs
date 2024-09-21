using Microsoft.AspNetCore.Identity;
using PublishingBusinessManagement.Helpers;
using PublishingBusinessManagement.Models;

namespace PublishingBusinessManagement
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<User> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            await CreateRoleIfNotExists(roleManager, AppRole.Admin);
            await CreateRoleIfNotExists(roleManager, AppRole.Staff);
            await CreateRoleIfNotExists(roleManager, AppRole.Customer);
            // Kiểm tra xem vai trò Admin đã tồn tại chưa
            if (!await roleManager.RoleExistsAsync(AppRole.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(AppRole.Admin));
            }

            // Tạo người dùng Admin nếu chưa có
            var adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                var user = new User
                {
                    UserName = "admin",
                    Email = "admin@example.com",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Admin@123");
                if (result.Succeeded)
                {
                    // Gán vai trò Admin cho người dùng
                    await userManager.AddToRoleAsync(user, AppRole.Admin);
                }
            }
        }
        private static async Task CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
