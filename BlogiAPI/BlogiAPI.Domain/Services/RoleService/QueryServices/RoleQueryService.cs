using BlogiAPI.Domain.DTOs;
using BlogiAPI.Domain.Repositories;
using BlogiAPI.Domain.Repositories.SqlFactory;

namespace BlogiAPI.Domain.Services.RoleService.QueryServices
{
    public class RoleQueryService(IRoleRepository repository)
    {
        public async Task<RoleDto?> GetRoleById(Guid roleId)
        {
            try
            {
                var (getRoleQuery, getRoleParameter) = SqlQueryFactory.GetRoleByIdQuery(roleId);
                var role = await repository.LoadOneData<RoleDto, object>(getRoleQuery, getRoleParameter);
                return role;
            }
            catch (Exception)
            {
                return null; 
            }
        }

        public async Task<RoleDto?> GetRoleByName(string roleName)
        {
            try
            {
                var (getRoleQuery, getRoleParameter) = SqlQueryFactory.GetRoleByNameQuery(roleName);
                var role = await repository.LoadOneData<RoleDto, object>(getRoleQuery, getRoleParameter);
                return role;
            }
            catch (Exception)
            {
                return null; 
            }
        }

        public async Task<List<RoleDto>?> GetAllRoles()
        {
            try
            {
                var (getAllRolesQuery, getAllRolesParameter) = SqlQueryFactory.GetAllRolesQuery();
                var roles = await repository.LoadData<RoleDto, object>(getAllRolesQuery, getAllRolesParameter);
                return roles;
            }
            catch (Exception)
            {
                return null; 
            }
        }
    }
}