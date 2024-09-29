using DataAccessLayer.IRepository.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository.Auth
{
    public class UserManagementRepository: IUserManagementRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityUser> FindByIdAsync(string id) => await _userManager.FindByIdAsync(id);

        public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync() => _userManager.Users.ToList();

        public async Task<IdentityResult> UpdateAsync(IdentityUser user) => await _userManager.UpdateAsync(user);

        public async Task<IdentityResult> DeleteAsync(IdentityUser user) => await _userManager.DeleteAsync(user);

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync() => _roleManager.Roles.ToList();

        public async Task<bool> IsInRoleAsync(IdentityUser user, string role) => await _userManager.IsInRoleAsync(user, role);

        public async Task<IdentityResult> RemoveFromRolesAsync(IdentityUser user, IEnumerable<string> roles) => await _userManager.RemoveFromRolesAsync(user, roles);

        public async Task<IdentityResult> AddToRolesAsync(IdentityUser user, IEnumerable<string> roles) => await _userManager.AddToRolesAsync(user, roles);

    }
}
