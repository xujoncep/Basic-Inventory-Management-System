using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IDDLRepository
    {
        Task<IEnumerable<SelectListItem>> GetCategoryDDL();
        Task<IEnumerable<SelectListItem>> GetCategoryDDL(int categoryid);
        Task<IEnumerable<SelectListItem>> GetSupplierDDL();
        Task<IEnumerable<SelectListItem>> GetSupplierDDL(int supplierId);
        Task<IEnumerable<SelectListItem>> GetCustomerDDL();
        Task<IEnumerable<SelectListItem>> GetCustomerDDL(int customerId);

        Task<IEnumerable<SelectListItem>> GetProductDDL();
        Task<IEnumerable<SelectListItem>> GetActiveProductDDL();

        Task<IEnumerable<SelectListItem>> GetAvailableProductDDL();
    }
}
