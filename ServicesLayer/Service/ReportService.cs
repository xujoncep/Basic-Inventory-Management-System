using DataAccessLayer.IRepository;
using DataAccessLayer.ViewModels;
using ServicesLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service
{
    public class ReportService: IReportService
    {
        private readonly IReportRepository _rRepo;

        public ReportService(IReportRepository rRepo)
        {
            _rRepo = rRepo;
        }

        public async Task<TotalItemVM> GetTotalItemCount()
        {
            return await _rRepo.GetTotalItemCount();
        }

        public async Task<InventoryReportVM> GetInventoryReport(InventoryReportVM model)
        {
            return await _rRepo.GetInventoryReport(model);
        }
    }
}
