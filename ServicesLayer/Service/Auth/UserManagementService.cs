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

    }
}
