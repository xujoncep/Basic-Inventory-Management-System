using DataAccessLayer.ViewModels.UserManagement;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService.Auth
{
    public interface IUserManagementService
    {
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
        Task<IdentityUser> GetUserByIdAsync(string id);
        Task<IdentityResult> UpdateUserAsync(User model);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<Dictionary<string, bool>> GetUserRolesAsync(string userId);
        Task<IdentityResult> ManageUserRolesAsync(string userId, List<RoleOfUser> roles);
    }
}
