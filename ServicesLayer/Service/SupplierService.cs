using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using ServicesLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierRepository _sRepo;
        public SupplierService(ISupplierRepository sRepo)
        {
            _sRepo = sRepo;
        }
        public async Task<List<Supplier>> GetAllSupplier()
        {
            var data = await _sRepo.GetAllSupplier();
            return data;
        }
        public async Task<Supplier> GetSupplierById(int SupplierId)
        {
            var data = await _sRepo.GetSupplierById(SupplierId);
            return data;
        }
        public async Task<bool> Create(Supplier model)
        {
            var data = await _sRepo.Create(model);
            return data;
        }
        public async Task<bool> Edit(Supplier model)
        {
            var data = await _sRepo.Edit(model);
            return data;
        }
    }
}
