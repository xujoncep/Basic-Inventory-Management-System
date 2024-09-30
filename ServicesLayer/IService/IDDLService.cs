using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService
{
    public interface IDDLService
    {
        Task<IEnumerable<SelectListItem>> GetCategoryDDL(int categoryid = 0);
        Task<IEnumerable<SelectListItem>> GetSupplierDDL(int supplierId = 0);
        Task<IEnumerable<SelectListItem>> GetCustomerDDL(int customerId = 0);
        Task<IEnumerable<SelectListItem>> GetProductDDL(bool IsActive = true);
        Task<IEnumerable<SelectListItem>> GetAvailableProductDDL();
    }
}
