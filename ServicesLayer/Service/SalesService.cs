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
    public class SalesService: ISalesService
    {
       
       
            private readonly ISalesRepository _sRepo;

            public SalesService(ISalesRepository sRepo)
            {
                _sRepo = sRepo;
            }

            public async Task<List<SalesOrderVM>> GetAllSalesOrder()
            {
                return await _sRepo.GetAllSalesOrder();
            }
            public async Task<bool> Create(SalesOrder model)
            {
                return await _sRepo.Create(model);
            }

            public async Task<int> GetAvailableQuantityByProductId(int productId)
            {
                return await _sRepo.GetAvailableQuantityByProductId(productId);
            }
     }
}
