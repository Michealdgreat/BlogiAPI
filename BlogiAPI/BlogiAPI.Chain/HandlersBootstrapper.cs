using Microsoft.Extensions.DependencyInjection;
using BlogiAPI.Chain.Handlers.Role;
using BlogiAPI.Chain.Handlers.User;

namespace BlogiAPI.Chain
{
    public static class HandlersBootstrapper
    {
        private static void RegisterHandlers(this IServiceCollection services)
        {
            // User Handlers
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<GetUserByEmailHandler>();
            services.AddScoped<GetAllUsersHandler>();

            // Role Handlers
            services.AddScoped<GetRoleByIdHandler>();
            services.AddScoped<GetRoleByNameHandler>();
            services.AddScoped<GetAllRolesHandler>();
            
            
            services.AddSingleton<AuthenticatorHandler>();
        }

        public static void RegisterAllHandlers(this IServiceCollection services)
        {
            RegisterHandlers(services);
        }
    }
}