using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository.Auth
{
    public interface IAccountRepository
    {
        Task<IdentityUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(IdentityUser user, string password);
    }
}
