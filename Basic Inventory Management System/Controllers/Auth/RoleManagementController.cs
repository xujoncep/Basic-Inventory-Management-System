using DataAccessLayer.ViewModels.RoleManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IService.Auth;

namespace Basic_Inventory_Management_System.Controllers.Auth
{
    public class RoleManagementController : Controller
    {
        private readonly IRoleManagementService _roleService;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleManagementController(IRoleManagementService roleService, UserManager<IdentityUser> userManager)
        {
            _roleService = roleService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(UserRole model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleService.CreateRoleAsync(model.RoleName);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new UserRole { Id = role.Id, RoleName = role.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(UserRole model)
        {
            var result = await _roleService.UpdateRoleAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("RoleList");
        }

        [HttpGet]
        public async Task<IActionResult> ManageUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var usersInRole = await _roleService.GetUsersInRoleAsync(roleId);
            if (usersInRole == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            ViewBag.roleName = usersInRole.FirstOrDefault()?.UserName;
            return View(usersInRole);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUsersInRole(List<UserInRole> model, string roleId)
        {
            var result = await _roleService.ManageUsersInRoleAsync(model, roleId);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}
