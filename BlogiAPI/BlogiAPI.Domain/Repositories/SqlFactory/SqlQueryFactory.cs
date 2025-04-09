using System;

namespace BlogiAPI.Domain.Repositories.SqlFactory;

public static class SqlQueryFactory
{
    
    public static (string sql, object parameters) GetRoleByIdQuery(Guid roleId) => ("SELECT * FROM get_role_by_id(@p_role_id)", new { p_role_id = roleId });
    public static (string sql, object parameters) GetAllRolesQuery() => ("SELECT * FROM get_all_roles()", null);
    public static (string sql, object parameters) GetRoleByNameQuery(string name) => ("SELECT * FROM get_role_by_name(@p_name)", new { p_name = name });
    
    public static (string sql, object parameters) GetUserByIdQuery(Guid userId) => ("SELECT * FROM get_user_by_id(@p_user_id)", new { p_user_id = userId });
    public static (string sql, object parameters) GetAllUsersQuery() => ("SELECT * FROM get_all_users()", null);
    public static (string sql, object parameters) GetUsersByRoleIdQuery(Guid roleId) => ("SELECT * FROM get_users_by_role_id(@p_role_id)", new { p_role_id = roleId });
    public static (string sql, object parameters) GetUserByEmailQuery(string email) => ("SELECT * FROM get_user_by_email(@p_email)", new { p_email = email });
    
    public static (string sql, object parameters) GetUserByEmailWithRoleQuery(string email)
    {
        return (
            "SELECT * FROM get_user_by_email_with_role(@p_email)",
            new { p_email = email }
        );
    }

    public static (string sql, object parameters) GetCategoryByIdQuery(Guid categoryId) => ("SELECT * FROM get_category_by_id(@p_category_id)", new { p_category_id = categoryId });
    public static (string sql, object parameters) GetAllCategoriesQuery() => ("SELECT * FROM get_all_categories()", null);
    public static (string sql, object parameters) GetPostByIdQuery(Guid postId) => ("SELECT * FROM get_post_by_id(@p_post_id)", new { p_post_id = postId });
    public static (string sql, object parameters) GetAllPostsQuery() => ("SELECT * FROM get_all_posts()", null);
    public static (string sql, object parameters) GetPostsByCategoryIdQuery(Guid categoryId) => ("SELECT * FROM get_posts_by_category_id(@p_category_id)", new { p_category_id = categoryId });
    public static (string sql, object parameters) GetBannerAdByIdQuery(Guid bannerId) => ("SELECT * FROM get_banner_ad_by_id(@p_banner_id)", new { p_banner_id = bannerId });
    public static (string sql, object parameters) GetAllBannerAdsQuery() => ("SELECT * FROM get_all_banner_ads()", null);
    public static (string sql, object parameters) GetCarouselBannerByIdQuery(Guid carouselId) => ("SELECT * FROM get_carousel_banner_by_id(@p_carousel_id)", new { p_carousel_id = carouselId });
    public static (string sql, object parameters) GetAllCarouselBannersQuery() => ("SELECT * FROM get_all_carousel_banners()", null);
}