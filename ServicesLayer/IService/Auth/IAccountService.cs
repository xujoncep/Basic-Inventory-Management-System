using DataAccessLayer.ViewModels.Auth.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService.Auth
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterUser model);
        Task<bool> LoginUserAsync(LoginUser model);
        Task LogoutUserAsync();
    }
}
