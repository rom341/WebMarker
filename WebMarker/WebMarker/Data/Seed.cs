using Microsoft.AspNetCore.Identity;
using System.Net;
using WebMarker.Models;

namespace WebMarker.Data
{
    public class Seed
    {
        //insert test values to database
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                if (!context.AppUsers.Any())
                {
                    context.AddRange(new List<AppUser>()
                    {
                        new AppUser
                        {
                            UserName = "user1",
                            Password = "password1",
                            Email = "email1"
                        },
                        new AppUser
                        {
                            UserName = "user2",
                            Password = "password2",
                            Email = "email2"
                        },
                        new AppUser
                        {
                            UserName = "user3",
                            Password = "password3",
                            Email = "email3"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(AppUserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(AppUserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(AppUserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(AppUserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "roman.murzik.antpnov@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "Lectum",
                        Email = adminUserEmail,
                        EmailConfirmed = true                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Lectum");
                    await userManager.AddToRoleAsync(newAdminUser, AppUserRoles.Admin);
                }

                string appUserEmail = "olifer.spec@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "olifer",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "olifer");
                    await userManager.AddToRoleAsync(newAppUser, AppUserRoles.User);
                }
            }
        }
    }
}
