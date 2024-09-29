using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMSDbContext _db;
        public CustomerRepository(IMSDbContext db)
        {
            _db = db;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            var data = await _db.Customer.ToListAsync();
            return data;
        }
        public async Task<Customer> GetCustomerById(int CustomerId)
        {
            var data = await _db.Customer.FindAsync(CustomerId);
            return data;
        }
        public async Task<bool> Create(Customer model)
        {
            try
            {
                await _db.Customer.AddAsync(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> Edit(Customer model)
        {
            try
            {
                _db.Customer.Update(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> IsCustomerCodeExist(int CustomerId, string CustomerCode)
        {
            if (CustomerId > 0)
            {
                return await _db.Customer.AnyAsync(x => x.CustomerId != CustomerId && x.CustomerCode == CustomerCode);
            }
            else
            {
                return await _db.Customer.AnyAsync(x => x.CustomerCode == CustomerCode);
            }
        }
    }
}
