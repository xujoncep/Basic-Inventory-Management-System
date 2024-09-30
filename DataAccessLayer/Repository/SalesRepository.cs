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
    public class SalesRepository: ISalesRepository
    {
        private readonly IMSDbContext _db;

        public SalesRepository(IMSDbContext db)
        {
            _db = db;
        }


        public async Task<List<SalesOrderVM>> GetAllSalesOrder()
        {
            var data = await (from so in _db.SalesOrder
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
                              }).OrderByDescending(x => x.SaleDate).ToListAsync();

            return data;
        }


        public async Task<bool> Create(SalesOrder model)
        {
            try
            {
                await _db.SalesOrder.AddAsync(model);

                var product = _db.Product.FirstOrDefault(x => x.ProductId == model.ProductId);
                product.QuantityInStock -= model.Quantity;
                _db.Product.Update(product);

                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<int> GetAvailableQuantityByProductId(int productId)
        {
            var product = await _db.Product.FindAsync(productId);
            int quantity = product.QuantityInStock;

            return quantity;
        }
    }
}
