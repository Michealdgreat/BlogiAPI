using Microsoft.Extensions.DependencyInjection;
using BlogiAPI.Chain.Handlers.Role;
using BlogiAPI.Chain.Handlers.User;
using BlogiAPI.Chain.Handlers.Category;
using BlogiAPI.Chain.Handlers.Post;
using BlogiAPI.Chain.Handlers.BannerAd;
using BlogiAPI.Chain.Handlers.Carousel;

namespace BlogiAPI.Chain
{
    public static class HandlersBootstrapper
    {
        private static void RegisterHandlers(this IServiceCollection services)
        {
            // User Handlers
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<UpdateUserHandler>();
            services.AddScoped<DeleteUserHandler>();
            services.AddScoped<GetUserByIdHandler>();
            services.AddScoped<GetUserByEmailHandler>();
            services.AddScoped<GetAllUsersHandler>();

            // Role Handlers
            services.AddScoped<CreateRoleHandler>();
            services.AddScoped<UpdateRoleHandler>();
            services.AddScoped<GetRoleByIdHandler>();
            services.AddScoped<GetRoleByNameHandler>();
            services.AddScoped<GetAllRolesHandler>();

            // Category Handlers
            services.AddScoped<CreateCategoryHandler>();
            services.AddScoped<UpdateCategoryHandler>();
            services.AddScoped<DeleteCategoryHandler>();
            services.AddScoped<GetAllCategoriesHandler>();

            // Post Handlers
            services.AddScoped<CreatePostHandler>();
            services.AddScoped<UpdatePostHandler>();
            services.AddScoped<DeletePostHandler>();
            services.AddScoped<GetPostByIdHandler>();
            services.AddScoped<GetPostsByCategoryIdHandler>();
            services.AddScoped<GetAllPostsHandler>();

            // BannerAd Handlers
            services.AddScoped<CreateBannerAdHandler>();
            services.AddScoped<UpdateBannerAdHandler>();
            services.AddScoped<DeleteBannerAdHandler>();
            services.AddScoped<GetBannerAdByIdHandler>();
            services.AddScoped<GetAllBannerAdsHandler>();

            // CarouselBanner Handlers
            services.AddScoped<CreateCarouselBannerHandler>();
            services.AddScoped<UpdateCarouselBannerHandler>();
            services.AddScoped<DeleteCarouselBannerHandler>();
            services.AddScoped<GetCarouselBannerByIdHandler>();
            services.AddScoped<GetAllCarouselBannersHandler>();

            // Authenticator Handler (unchanged)
            services.AddSingleton<AuthenticatorHandler>();
        }

        public static void RegisterAllHandlers(this IServiceCollection services)
        {
            RegisterHandlers(services);
        }
    }
}