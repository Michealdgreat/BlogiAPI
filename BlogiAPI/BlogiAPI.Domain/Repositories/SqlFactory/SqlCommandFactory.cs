using System;

namespace BlogiAPI.Domain.Repositories.SqlFactory
{
    public static class SqlCommandFactory
    {
       
        public static (string sql, object parameters) CreateRoleCommand(Guid roleId, string name)
        {
            return (
                "CALL create_role(@p_role_id, @p_name)",
                new { p_role_id = roleId, p_name = name }
            );
        }

        public static (string sql, object parameters) UpdateRoleCommand(Guid roleId, string name)
        {
            return (
                "CALL update_role(@p_role_id, @p_name)",
                new { p_role_id = roleId, p_name = name }
            );
        }

        public static (string sql, object parameters) DeleteRoleCommand(Guid roleId)
        {
            return (
                "CALL delete_role(@p_role_id)",
                new { p_role_id = roleId }
            );
        }

      
        public static (string sql, object parameters) CreateUserCommand(Guid userId, string firstname, string lastname, string email, string passwordHash, string address, Guid roleId)
        {
            return (
                "CALL create_user(@p_user_id, @p_firstname, @p_lastname, @p_email, @p_password_hash, @p_address, @p_role_id)",
                new { p_user_id = userId, p_firstname = firstname, p_lastname = lastname, p_email = email, p_password_hash = passwordHash, p_address = address, p_role_id = roleId }
            );
        }

        public static (string sql, object parameters) UpdateUserCommand(Guid userId, string firstname, string lastname, string email, string address)
        {
            return (
                "CALL update_user(@p_user_id, @p_firstname, @p_lastname, @p_email, @p_address)",
                new { p_user_id = userId, p_firstname = firstname, p_lastname = lastname, p_email = email, p_address = address }
            );
        }

        public static (string sql, object parameters) DeleteUserCommand(Guid userId)
        {
            return (
                "CALL delete_user(@p_user_id)",
                new { p_user_id = userId }
            );
        }

       
        public static (string sql, object parameters) CreateCategoryCommand(Guid categoryId, string name, string description)
        {
            return (
                "CALL create_category(@p_category_id, @p_name, @p_description)",
                new { p_category_id = categoryId, p_name = name, p_description = description }
            );
        }

        public static (string sql, object parameters) UpdateCategoryCommand(Guid categoryId, string name, string description)
        {
            return (
                "CALL update_category(@p_category_id, @p_name, @p_description)",
                new { p_category_id = categoryId, p_name = name, p_description = description }
            );
        }

        public static (string sql, object parameters) DeleteCategoryCommand(Guid categoryId)
        {
            return (
                "CALL delete_category(@p_category_id)",
                new { p_category_id = categoryId }
            );
        }

     
        public static (string sql, object parameters) CreatePostCommand(Guid postId, string title, string content, string imageUrl, Guid categoryId, Guid authorId, bool isPublished)
        {
            return (
                "CALL create_post(@p_post_id, @p_title, @p_content, @p_image_url, @p_category_id, @p_author_id, @p_is_published)",
                new { p_post_id = postId, p_title = title, p_content = content, p_image_url = imageUrl, p_category_id = categoryId, p_author_id = authorId, p_is_published = isPublished }
            );
        }

        public static (string sql, object parameters) UpdatePostCommand(Guid postId, string title, string content, string imageUrl, Guid categoryId, bool isPublished)
        {
            return (
                "CALL update_post(@p_post_id, @p_title, @p_content, @p_image_url, @p_category_id, @p_is_published)",
                new { p_post_id = postId, p_title = title, p_content = content, p_image_url = imageUrl, p_category_id = categoryId, p_is_published = isPublished }
            );
        }

        public static (string sql, object parameters) DeletePostCommand(Guid postId)
        {
            return (
                "CALL delete_post(@p_post_id)",
                new { p_post_id = postId }
            );
        }

    
        public static (string sql, object parameters) CreateBannerAdCommand(Guid bannerId, string title, string imageUrl, string redirectUrl, DateTime startDate, DateTime endDate, bool isActive)
        {
            return (
                "CALL create_banner_ad(@p_banner_id, @p_title, @p_image_url, @p_redirect_url, @p_start_date, @p_end_date, @p_is_active)",
                new { p_banner_id = bannerId, p_title = title, p_image_url = imageUrl, p_redirect_url = redirectUrl, p_start_date = startDate, p_end_date = endDate, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) UpdateBannerAdCommand(Guid bannerId, string title, string imageUrl, string redirectUrl, DateTime startDate, DateTime endDate, bool isActive)
        {
            return (
                "CALL update_banner_ad(@p_banner_id, @p_title, @p_image_url, @p_redirect_url, @p_start_date, @p_end_date, @p_is_active)",
                new { p_banner_id = bannerId, p_title = title, p_image_url = imageUrl, p_redirect_url = redirectUrl, p_start_date = startDate, p_end_date = endDate, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) DeleteBannerAdCommand(Guid bannerId)
        {
            return (
                "CALL delete_banner_ad(@p_banner_id)",
                new { p_banner_id = bannerId }
            );
        }
        
        public static (string sql, object parameters) CreateCarouselBannerCommand(Guid carouselId, string title, string imageUrl, string description, int displayOrder, string redirectUrl, bool isActive)
        {
            return (
                "CALL create_carousel_banner(@p_carousel_id, @p_title, @p_image_url, @p_description, @p_display_order, @p_redirect_url, @p_is_active)",
                new { p_carousel_id = carouselId, p_title = title, p_image_url = imageUrl, p_description = description, p_display_order = displayOrder, p_redirect_url = redirectUrl, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) UpdateCarouselBannerCommand(Guid carouselId, string title, string imageUrl, string description, int displayOrder, string redirectUrl, bool isActive)
        {
            return (
                "CALL update_carousel_banner(@p_carousel_id, @p_title, @p_image_url, @p_description, @p_display_order, @p_redirect_url, @p_is_active)",
                new { p_carousel_id = carouselId, p_title = title, p_image_url = imageUrl, p_description = description, p_display_order = displayOrder, p_redirect_url = redirectUrl, p_is_active = isActive }
            );
        }

        public static (string sql, object parameters) DeleteCarouselBannerCommand(Guid carouselId)
        {
            return (
                "CALL delete_carousel_banner(@p_carousel_id)",
                new { p_carousel_id = carouselId }
            );
        }
    }
}