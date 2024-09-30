using DataAccessLayer.Data;
using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ReportRepository: IReportRepository
    {
        private readonly IMSDbContext _db;

        public ReportRepository(IMSDbContext db)
        {
            _db = db;
        }


        public async Task<TotalItemVM> GetTotalItemCount()
        {
            TotalItemVM data = new TotalItemVM()
            {
                TotalCategory = await _db.Category.CountAsync(),
                TotalCustomer = await _db.Customer.CountAsync(),
                TotalSupplier = await _db.Supplier.CountAsync(),
                TotalProduct = await _db.Product.CountAsync(),
                TotalPurchaseOrder = await _db.PurchaseOrder.CountAsync(),
                TotalSalesOrder = await _db.SalesOrder.CountAsync()
            };

            return data;
        }


        public async Task<InventoryReportVM> GetInventoryReport(InventoryReportVM model)
        {
            var query = (from p in _db.Product
                         join c in _db.Category on p.CategoryId equals c.CategoryId into pcGroup
                         from c in pcGroup.DefaultIfEmpty()
                         select new Product
                         {
                             ProductId = p.ProductId,
                             ProductName = p.ProductName,
                             CategoryId = p.CategoryId,
                             CategoryName = c.CategoryName,
                             BasePrice = p.BasePrice,
                             QuantityInStock = p.QuantityInStock,
                             IsActive = p.IsActive,
                             TotalPrice = p.BasePrice * p.QuantityInStock
                         });

            if (model.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == model.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(model.ProductName))
            {
                query = query.Where(x => x.ProductName.Contains(model.ProductName.Trim()));
            }

            var data = await query.ToListAsync();

            model.ProductList = data;
            model.TotalQuantity = data.Sum(x => x.QuantityInStock);
            model.GrandTotalPrice = data.Sum(x => x.TotalPrice);

            return model;
        }
    }
}
