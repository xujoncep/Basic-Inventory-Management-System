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


        public async Task<PurchaseReportVM> GetPurchaseReport(PurchaseReportVM model)
        {
            var query = (from po in _db.PurchaseOrder
                         join pr in _db.Product on po.ProductId equals pr.ProductId
                         join s in _db.Supplier on po.SupplierId equals s.SupplierId into posGroup
                         from s in posGroup.DefaultIfEmpty()
                         select new PurchaseOrderVM
                         {
                             PurchaseOrderId = po.PurchaseOrderId,
                             ProductId = po.ProductId,
                             ProductName = pr.ProductName,
                             SupplierId = po.SupplierId,
                             SupplierName = s.SupplierName,
                             Quantity = po.Quantity,
                             PurchasePrice = po.PurchasePrice,
                             PurchaseDate = po.PurchaseDate,
                             TotalPrice = po.Quantity * po.PurchasePrice
                         });



            if (model.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == model.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(model.SupplierName))
            {
                query = query.Where(x => x.SupplierName.Contains(model.SupplierName.Trim()));
            }

            if (model.StartDate != null)
            {
                query = query.Where(x => x.PurchaseDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(x => x.PurchaseDate <= model.EndDate);
            }

            var data = await query.ToListAsync();

            model.PurchaseOrderList = data;
            model.TotalQuantity = data.Sum(x => x.Quantity);
            model.GrandTotalPrice = data.Sum(x => x.TotalPrice);

            return model;
        }



        public async Task<SalesReportVM> GetSalesReport(SalesReportVM model)
        {
            var query = (from so in _db.SalesOrder
                         join pr in _db.Product on so.ProductId equals pr.ProductId
                         join c in _db.Customer on so.CustomerId equals c.CustomerId into socGroup
                         from c in socGroup.DefaultIfEmpty()
                         select new SalesOrderVM
                         {
                             SalesOrderId = so.SalesOrderId,
                             ProductId = so.ProductId,
                             ProductName = pr.ProductName,
                             CustomerId = so.CustomerId,
                             CustomerName = c.CustomerName,
                             Quantity = so.Quantity,
                             SalePrice = so.SalePrice,
                             SaleDate = so.SaleDate,
                             TotalPrice = so.Quantity * so.SalePrice
                         });



            if (model.ProductId > 0)
            {
                query = query.Where(x => x.ProductId == model.ProductId);
            }

            if (!string.IsNullOrWhiteSpace(model.CustomerName))
            {
                query = query.Where(x => x.CustomerName.Contains(model.CustomerName.Trim()));
            }

            if (model.StartDate != null)
            {
                query = query.Where(x => x.SaleDate >= model.StartDate);
            }
            if (model.EndDate != null)
            {
                query = query.Where(x => x.SaleDate <= model.EndDate);
            }

            var data = await query.ToListAsync();

            model.SalesOrderList = data;
            model.TotalQuantity = data.Sum(x => x.Quantity);
            model.GrandTotalPrice = data.Sum(x => x.TotalPrice);

            return model;
        }
    }
}
