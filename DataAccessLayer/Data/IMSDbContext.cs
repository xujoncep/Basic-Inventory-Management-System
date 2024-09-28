using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class IMSDbContext : IdentityDbContext
    {

        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options)
        {
        
        }
    }
}
