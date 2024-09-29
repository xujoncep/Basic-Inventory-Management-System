using DataAccessLayer.ViewModels.UserManagement;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.IService.Auth;

namespace Basic_Inventory_Management_System.Controllers.Auth
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService userService;

        public UserManagementController(IUserManagementService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var users = await userService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new User { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User model)
        {
            var result = await userService.UpdateUserAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await userService.DeleteUserAsync(id);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("UserList");
        }

        [HttpGet]
        public async Task<IActionResult> ManageRolesOfUser(string userId)
        {
            ViewBag.userId = userId;

            var user = await userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            ViewBag.userEmail = user.Email;
            var roles = await userService.GetUserRolesAsync(userId);
            return View(roles);
        }

        [HttpPost]
        public async Task<IActionResult> ManageRolesOfUser(List<RoleOfUser> model, string userId)
        {
            var result = await userService.ManageUserRolesAsync(userId, model);
            if (result.Succeeded)
            {
                return RedirectToAction("UserList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }
    }
}
