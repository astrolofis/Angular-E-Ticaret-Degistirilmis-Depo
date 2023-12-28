using API.Core.DbModels.Identity;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<StoreContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            services.AddAuthentication();

            return services;
        }
    }
}
