using DataAccessLayer.IRepository.Auth;
using DataAccessLayer.ViewModels.UserManagement;
using Microsoft.AspNetCore.Identity;
using ServicesLayer.IService.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service.Auth
{
    public class UserManagementService: IUserManagementService
    {
        private readonly IUserManagementRepository _userRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public UserManagementService(IUserManagementRepository userRepository, UserManager<IdentityUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<IEnumerable<IdentityUser>> GetAllUsersAsync() => await _userRepository.GetAllUsersAsync();

        public async Task<IdentityUser> GetUserByIdAsync(string id) => await _userRepository.FindByIdAsync(id);

        public async Task<IdentityResult> UpdateUserAsync(User model)
        {
            var user = await _userRepository.FindByIdAsync(model.Id);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = $"User not found" });

            user.Email = model.Email;
            user.UserName = model.Email;

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return user == null ? IdentityResult.Failed(new IdentityError { Description = $"User not found" }) : await _userRepository.DeleteAsync(user);
        }

        public async Task<Dictionary<string, bool>> GetUserRolesAsync(string userId)
        {
            var roles = await _userRepository.GetAllRolesAsync();
            var userRoles = new Dictionary<string, bool>();

            foreach (var role in roles)
            {
                userRoles[role.Name] = await _userRepository.IsInRoleAsync(await _userRepository.FindByIdAsync(userId), role.Name);
            }

            return userRoles;
        }

        public async Task<IdentityResult> ManageUserRolesAsync(string userId, List<RoleOfUser> roles)
        {
            var user = await _userRepository.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = $"User not found" });

            var currentRoles = await _userManager.GetRolesAsync(user);
            var result = await _userRepository.RemoveFromRolesAsync(user, currentRoles);
            if (!result.Succeeded) return result;

            var selectedRoles = roles.Where(x => x.IsSelected).Select(y => y.RoleName);
            return await _userRepository.AddToRolesAsync(user, selectedRoles);
        }

    }
}
