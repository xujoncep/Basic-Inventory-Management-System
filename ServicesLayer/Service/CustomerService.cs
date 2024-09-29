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
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerRepository _cRepo;
        public CustomerService(ICustomerRepository cRepo)
        {
            _cRepo = cRepo;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            var data = await _cRepo.GetAllCustomer();
            return data;
        }
        public async Task<Customer> GetCustomerById(int CustomerId)
        {
            var data = await _cRepo.GetCustomerById(CustomerId);
            return data;
        }
        public async Task<bool> Create(Customer model)
        {
            var data = await _cRepo.Create(model);
            return data;
        }
        public async Task<bool> Edit(Customer model)
        {
            var data = await _cRepo.Edit(model);
            return data;
        }
        public async Task<bool> IsCustomerCodeExist(int CustomerId, string CustomerCode)
        {
            return await _cRepo.IsCustomerCodeExist(CustomerId, CustomerCode);
        }

    }
}
