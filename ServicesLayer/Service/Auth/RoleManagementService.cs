using DataAccessLayer.IRepository.Auth;
using DataAccessLayer.ViewModels.RoleManagement;
using Microsoft.AspNetCore.Identity;
using ServicesLayer.IService.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service.Auth
{
    public class RoleManagementService: IRoleManagementService
    {
        private readonly IRoleManagementRepository _roleRepository;

        public RoleManagementService(IRoleManagementRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            return await _roleRepository.GetRoleByIdAsync(id);
        }

        public async Task<IdentityResult> CreateRoleAsync(string roleName)
        {
            var identityRole = new IdentityRole { Name = roleName };
            return await _roleRepository.CreateRoleAsync(identityRole);
        }

        public async Task<IdentityResult> UpdateRoleAsync(UserRole model)
        {
            var role = await _roleRepository.GetRoleByIdAsync(model.Id);
            if (role == null) return IdentityResult.Failed(new IdentityError { Description = "Role not found." });

            role.Name = model.RoleName;
            return await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task<IdentityResult> DeleteRoleAsync(string id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null) return IdentityResult.Failed(new IdentityError { Description = "Role not found." });

            return await _roleRepository.DeleteRoleAsync(role);
        }

    }
}
