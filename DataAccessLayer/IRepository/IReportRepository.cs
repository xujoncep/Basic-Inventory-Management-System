using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IReportRepository
    {
        Task<TotalItemVM> GetTotalItemCount();
        Task<InventoryReportVM> GetInventoryReport(InventoryReportVM model);
    }
}
