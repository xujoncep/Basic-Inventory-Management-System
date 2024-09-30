using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class DDLRepository: IDDLRepository
    {
        private readonly IMSDbContext _db;
        public DDLRepository(IMSDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoryDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Category.Where(x => x.IsActive == 1)
              .Select(c => new SelectListItem
              {
                  Value = c.CategoryId.ToString(),
                  Text = c.CategoryName.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoryDDL(int categoryid)
        {
            IEnumerable<SelectListItem> datas = await _db.Category.Where(x => x.IsActive == 1 || x.CategoryId == categoryid)
              .Select(c => new SelectListItem
              {
                  Value = c.CategoryId.ToString(),
                  Text = c.CategoryName.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }
        public async Task<IEnumerable<SelectListItem>> GetSupplierDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Supplier.Where(x => x.IsActive == 1)
              .Select(s => new SelectListItem
              {
                  Value = s.SupplierId.ToString(),
                  Text = s.SupplierName.ToString() + "-" + s.SupplierCode.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }
        public async Task<IEnumerable<SelectListItem>> GetSupplierDDL(int supplierId)
        {
            IEnumerable<SelectListItem> datas = await _db.Supplier.Where(x => x.IsActive == 1 || x.SupplierId == supplierId)
              .Select(s => new SelectListItem
              {
                  Value = s.SupplierId.ToString(),
                  Text = s.SupplierName.ToString() + "-" + s.SupplierCode.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }
        public async Task<IEnumerable<SelectListItem>> GetCustomerDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Customer.Where(x => x.IsActive == 1)
              .Select(s => new SelectListItem
              {
                  Value = s.CustomerId.ToString(),
                  Text = s.CustomerName.ToString() + "-" + s.CustomerCode.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetCustomerDDL(int customerId)
        {
            IEnumerable<SelectListItem> datas = await _db.Customer.Where(x => x.IsActive == 1 || x.CustomerId == customerId)
              .Select(s => new SelectListItem
              {
                  Value = s.CustomerId.ToString(),
                  Text = s.CustomerName.ToString() + "-" + s.CustomerCode.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetProductDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Product
              .Select(s => new SelectListItem
              {
                  Value = s.ProductId.ToString(),
                  Text = s.ProductName.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetActiveProductDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Product.Where(x => x.IsActive == 1)
              .Select(s => new SelectListItem
              {
                  Value = s.ProductId.ToString(),
                  Text = s.ProductName.ToString()
              }).Distinct().ToListAsync();
            return datas.OrderBy(x => x.Text).ToList();
        }

        public async Task<IEnumerable<SelectListItem>> GetAvailableProductDDL()
        {
            IEnumerable<SelectListItem> datas = await _db.Product.Where(x => x.IsActive == 1 && x.QuantityInStock > 0)
              .Select(s => new SelectListItem
              {
                  Value = s.ProductId.ToString(),
                  Text = s.ProductName.ToString()
              }).Distinct().ToListAsync();

            return datas.OrderBy(x => x.Text).ToList();
        }

    }
}
