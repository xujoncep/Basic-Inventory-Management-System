using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IPurchaseRepository
    {
        Task<List<PurchaseOrderVM>> GetAllPurchaseOrder();
        Task<bool> Create(PurchaseOrder model);
    }
}
