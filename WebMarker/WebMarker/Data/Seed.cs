using WebMarker.Models;

namespace WebMarker.Data
{
    public class Seed
    {
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
                            Login = "user1",
                            Password = "password1",
                            Email = "email1"
                        },
                        new AppUser
                        {
                            Login = "user2",
                            Password = "password2",
                            Email = "email2"
                        },
                        new AppUser
                        {
                            Login = "user3",
                            Password = "password3",
                            Email = "email3"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
