using API.Core.DbModels.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.DataContext
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Mehmet",
                    Email = "mehmet.muharrem@ceylan.com",
                    UserName = "mehmet.muharrem@ceylan.com",
                    Address = new Address
                    {
                        FirstName = "Mehmet",
                        LastName = "Ceylan",
                        Street = "Istanbun Cad",
                        City = "Istanbul",
                        State = "TR",
                        ZipCode = "34000"
                    }
                };
                await userManager.CreateAsync(user, "MyPassword!23");
            }
        }
    }
}
