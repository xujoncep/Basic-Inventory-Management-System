using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using ServicesLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service
{
    public class PurchaseServic: IPurchaseServic
    {
        private readonly IPurchaseRepository _pRepo;

        public PurchaseServic(IPurchaseRepository pRepo)
        {
            _pRepo = pRepo;
        }

        public async Task<List<PurchaseOrderVM>> GetAllPurchaseOrder()
        {
            return await _pRepo.GetAllPurchaseOrder();
        }
        public async Task<bool> Create(PurchaseOrder model)
        {
            return await _pRepo.Create(model);
        }
    }
}
