using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository.Auth
{
    public interface IUserManagementRepository
    {
        Task<IdentityUser> FindByIdAsync(string id);
        Task<IEnumerable<IdentityUser>> GetAllUsersAsync();
        Task<IdentityResult> UpdateAsync(IdentityUser user);
        Task<IdentityResult> DeleteAsync(IdentityUser user);
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<bool> IsInRoleAsync(IdentityUser user, string role);
        Task<IdentityResult> RemoveFromRolesAsync(IdentityUser user, IEnumerable<string> roles);
        Task<IdentityResult> AddToRolesAsync(IdentityUser user, IEnumerable<string> roles);
    }
}
