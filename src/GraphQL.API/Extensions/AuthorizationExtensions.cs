using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.API.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IAuthorizationHandler, AuthorizationHandler>();
            //services.AddTransient<IAuthorizationHandler, UserRoleAuthorizationHandler>();

            services.AddAuthorization();
            return services;
        }
    }

}
