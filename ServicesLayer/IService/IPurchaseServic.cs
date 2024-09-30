using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService
{
    public interface IPurchaseServic
    {
        Task<List<PurchaseOrderVM>> GetAllPurchaseOrder();
        Task<bool> Create(PurchaseOrder model);
    }
}
