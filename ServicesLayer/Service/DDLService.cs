using DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service
{
    public class DDLService : IDDLService
    {
        private readonly IDDLRepository _ddlRepo;
        public DDLService(IDDLRepository ddlRepo)
        {
            _ddlRepo = ddlRepo;
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoryDDL(int categoryid = 0)
        {
            if (categoryid == 0)
            {
                return await _ddlRepo.GetCategoryDDL();
            }
            else
            {
                return await _ddlRepo.GetCategoryDDL(categoryid);
            }
        }
        public async Task<IEnumerable<SelectListItem>> GetSupplierDDL(int supplierId = 0)
        {
            if (supplierId == 0)
            {
                return await _ddlRepo.GetSupplierDDL();
            }
            else
            {
                return await _ddlRepo.GetSupplierDDL(supplierId);
            }
        }
        public async Task<IEnumerable<SelectListItem>> GetCustomerDDL(int customerId = 0)
        {
            if (customerId == 0)
            {
                return await _ddlRepo.GetCustomerDDL();
            }
            else
            {
                return await _ddlRepo.GetCustomerDDL(customerId);
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetProductDDL(bool IsActive = true)
        {
            if (IsActive)
            {
                return await _ddlRepo.GetActiveProductDDL();
            }
            else
            {
                return await _ddlRepo.GetProductDDL();
            }
        }

        public async Task<IEnumerable<SelectListItem>> GetAvailableProductDDL()
        {
            return await _ddlRepo.GetAvailableProductDDL();
        }

    }
}
