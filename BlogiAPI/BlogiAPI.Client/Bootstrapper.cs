using Microsoft.Extensions.DependencyInjection;
using BlogiAPI.Client.Orchestrators;
using BlogiAPI.Domain.Repositories.Base;
using BlogiAPI.Domain.Services.Auth;
using BlogiAPI.Domain.Services.BannerAdService.CommandService;
using BlogiAPI.Domain.Services.BannerAdService.QueryServices;
using BlogiAPI.Domain.Services.RoleService.CommandService;
using BlogiAPI.Domain.Services.RoleService.QueryServices;
using BlogiAPI.Domain.Services.UserServices.CommandServices;
using BlogiAPI.Domain.Services.UserServices.QueryServices;
using BlogiAPI.Domain.Services.CarouselBannerService.CommandService;
using BlogiAPI.Domain.Services.CarouselBannerService.QueryServices;
using BlogiAPI.Domain.Services.CategoryService.CommandService;
using BlogiAPI.Domain.Services.CategoryService.QueryServices;
using BlogiAPI.Domain.Services.PostService.CommandService;
using BlogiAPI.Domain.Services.PostService.QueryServices;

namespace BlogiAPI.Client
{
    public static class Bootstrapper
    {
        public static void RegisterOrchestrators(this IServiceCollection services)
        {
            // Register command services
            services.AddScoped<RoleCommandService>();
            services.AddScoped<UserCommandServices>();
            services.AddScoped<CategoryCommandService>();
            services.AddScoped<PostCommandService>();
            services.AddScoped<BannerAdCommandService>();
            services.AddScoped<CarouselBannerCommandService>();

            // Register query services
            services.AddScoped<RoleQueryService>();
            services.AddScoped<UserQueryService>();
            services.AddScoped<CategoryQueryService>();
            services.AddScoped<PostQueryService>();
            services.AddScoped<BannerAdQueryService>();
            services.AddScoped<CarouselBannerQueryService>();

            // Register AuthService
            services.AddSingleton<AuthService>();

            // Register orchestrators
            services.AddScoped<RoleOrchestrator>();
            services.AddScoped<UserOrchestrator>();
            services.AddScoped<CategoryOrchestrator>();
            services.AddScoped<PostOrchestrator>();
            services.AddScoped<BannerAdOrchestrator>();
            services.AddScoped<CarouselBannerOrchestrator>();

            // Register base repository
            services.AddSingleton<IBaseRepository, BaseRepository>();
        }
    }
}