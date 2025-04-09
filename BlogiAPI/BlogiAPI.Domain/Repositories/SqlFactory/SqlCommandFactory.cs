using System;

namespace BlogiAPI.Domain.Repositories.SqlFactory
{
    public static class SqlCommandFactory
    {
        public static (string sql, object parameters) CreateRoleCommand(Guid roleId, string name)
        {
            return (
                "create_role",
                new { p_role_id = roleId, p_name = name }
            );
        }

        public static (string sql, object parameters) UpdateRoleCommand(Guid roleId, string name)
        {
            return (
                "update_role",
                new { p_role_id = roleId, p_name = name }
            );
        }

        public static (string sql, object parameters) DeleteRoleCommand(Guid roleId)
        {
            return (
                "delete_role",
                new { p_role_id = roleId }
            );
        }

        public static (string sql, object parameters) CreateUserCommand(Guid userId, string firstname, string lastname, string email, string passwordHash, string address, Guid roleId)
        {
            return (
                "create_user",
                new { p_user_id = userId, p_firstname = firstname, p_lastname = lastname, p_email = email, p_password_hash = passwordHash, p_address = address, p_role_id = roleId }
            );
        }

        public static (string sql, object parameters) UpdateUserCommand(Guid userId, string firstname, string lastname, string email, string address)
        {
            return (
                "update_user",
                new { p_user_id = userId, p_firstname = firstname, p_lastname = lastname, p_email = email, p_address = address }
            );
        }

        public static (string sql, object parameters) DeleteUserCommand(Guid userId)
        {
            return (
                "delete_user",
                new { p_user_id = userId }
            );
        }

        public static (string sql, object parameters) CreateCategoryCommand(Guid categoryId, string name, string description)
        {
            return (
                "create_category",
                new { p_category_id = categoryId, p_name = name, p_description = description }
            );
        }

        public static (string sql, object parameters) UpdateCategoryCommand(Guid categoryId, string name, string description)
        {
            return (
                "update_category",
                new { p_category_id = categoryId, p_name = name, p_description = description }
            );
        }

        public static (string sql, object parameters) DeleteCategoryCommand(Guid categoryId)
        {
            return (
                "delete_category",
                new { p_category_id = categoryId }
            );
        }

        public static (string sql, object parameters) CreatePostCommand(Guid postId, string title, string content, string imageUrl, Guid categoryId, Guid authorId, bool isPublished)
        {
            return (
                "create_post",
                new { p_post_id = postId, p_title = title, p_content = content, p_image_url = imageUrl, p_category_id = categoryId, p_author_id = authorId, p_is_published = isPublished }
            );
        }

        public static (string sql, object parameters) UpdatePostCommand(Guid postId, string title, string content, string imageUrl, Guid categoryId, bool isPublished)
        {
            return (
                "update_post",
                new { p_post_id = postId, p_title = title, p_content = content, p_image_url = imageUrl, p_category_id = categoryId, p_is_published = isPublished }
            );
        }

        public static (string sql, object parameters) DeletePostCommand(Guid postId)
        {
            return (
                "delete_post",
                new { p_post_id = postId }
            );
        }

        public static (string sql, object parameters) CreateBannerAdCommand(Guid bannerId, string title, string imageUrl, string redirectUrl, DateTime startDate, DateTime endDate, bool isActive)
        {
            return (
                "create_banner_ad",
                new { p_banner_id = bannerId, p_title = title, p_image_url = imageUrl, p_redirect_url = redirectUrl, p_start_date = startDate, p_end_date = endDate, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) UpdateBannerAdCommand(Guid bannerId, string title, string imageUrl, string redirectUrl, DateTime startDate, DateTime endDate, bool isActive)
        {
            return (
                "update_banner_ad",
                new { p_banner_id = bannerId, p_title = title, p_image_url = imageUrl, p_redirect_url = redirectUrl, p_start_date = startDate, p_end_date = endDate, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) DeleteBannerAdCommand(Guid bannerId)
        {
            return (
                "delete_banner_ad",
                new { p_banner_id = bannerId }
            );
        }

        public static (string sql, object parameters) CreateCarouselBannerCommand(Guid carouselId, string title, string imageUrl, string description, int displayOrder, string redirectUrl, bool isActive)
        {
            return (
                "create_carousel_banner",
                new { p_carousel_id = carouselId, p_title = title, p_image_url = imageUrl, p_description = description, p_display_order = displayOrder, p_redirect_url = redirectUrl, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) UpdateCarouselBannerCommand(Guid carouselId, string title, string imageUrl, string description, int displayOrder, string redirectUrl, bool isActive)
        {
            return (
                "update_carousel_banner",
                new { p_carousel_id = carouselId, p_title = title, p_image_url = imageUrl, p_description = description, p_display_order = displayOrder, p_redirect_url = redirectUrl, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) DeleteCarouselBannerCommand(Guid carouselId)
        {
            return (
                "delete_carousel_banner",
                new { p_carousel_id = carouselId }
            );
        }
    }
}