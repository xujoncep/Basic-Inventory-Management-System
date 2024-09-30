using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService
{
    public interface IReportService
    {
        Task<TotalItemVM> GetTotalItemCount();
        Task<InventoryReportVM> GetInventoryReport(InventoryReportVM model);
        Task<PurchaseReportVM> GetPurchaseReport(PurchaseReportVM model);
        Task<SalesReportVM> GetSalesReport(SalesReportVM model);
    }
}
