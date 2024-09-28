using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataAccessLayer.IRepository.Auth;
using DataAccessLayer.ViewModels.Auth.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLayer.IService.Auth;

namespace ServicesLayer.Service.Auth
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(IAccountRepository accountRepository, SignInManager<IdentityUser> signInManager)
        {
            _accountRepository = accountRepository;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterUser model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            return await _accountRepository.CreateUserAsync(user, model.Password);
        }

        public async Task<bool> LoginUserAsync(LoginUser model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }

        public async Task LogoutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
