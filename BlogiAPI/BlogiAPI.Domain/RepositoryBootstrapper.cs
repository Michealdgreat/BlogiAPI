using Microsoft.Extensions.DependencyInjection;
using BlogiAPI.Domain.Repositories;

namespace BlogiAPI.Domain
{
    public static class RepositoryBootstrapper
    {
        private static void RegisterRepositories(this IServiceCollection services)
        {
            
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>(); 
          
        }

        public static void RegisterAllRepositories(this IServiceCollection services)
        {
            RegisterRepositories(services);
        }
    }
}