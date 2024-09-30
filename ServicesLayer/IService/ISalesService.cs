using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService
{
    public interface ISalesService
    {
        Task<List<SalesOrderVM>> GetAllSalesOrder();
        Task<bool> Create(SalesOrder model);
        Task<int> GetAvailableQuantityByProductId(int productId);
    }
}
