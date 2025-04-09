using Microsoft.Extensions.DependencyInjection;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.Base;
using BlogiAPI.Domain.Services.Auth;

using BlogiAPI.Domain.Services.RoleService.CommandService;
using BlogiAPI.Domain.Services.RoleService.QueryServices;

using BlogiAPI.Domain.Services.UserServices.CommandServices;
using BlogiAPI.Domain.Services.UserServices.QueryServices;


namespace BlogiAPI.Client
{
    public static class Bootstrapper
    {
        public static void RegisterOrchestrators(this IServiceCollection services)
        {
            // Register command services
           
            services.AddScoped<RoleCommandService>();
           
            services.AddScoped<UserCommandServices>();
            
            services.AddSingleton<AuthService>();


            // Register query services
            services.AddScoped<RoleQueryService>();
            services.AddScoped<UserQueryService>();
           

            // Register orchestrators
            services.AddScoped<RoleOrchestrator>();
            services.AddScoped<UserOrchestrator>();
            
            
         services.AddSingleton<IBaseRepository, BaseRepository>();
           
            
            
           
        }
    }
}