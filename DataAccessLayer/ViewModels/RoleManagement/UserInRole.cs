using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels.RoleManagement
{
    public class UserInRole
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
