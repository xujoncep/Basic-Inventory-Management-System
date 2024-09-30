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
    public class PurchaseRepository: IPurchaseRepository
    {
        private readonly IMSDbContext _db;

        public PurchaseRepository(IMSDbContext db)
        {
            _db = db;
        }


        public async Task<List<PurchaseOrderVM>> GetAllPurchaseOrder()
        {
            var data = await (from po in _db.PurchaseOrder
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
                              }).OrderByDescending(x => x.PurchaseDate).ToListAsync();

            return data;
        }


        public async Task<bool> Create(PurchaseOrder model)
        {
            try
            {
                await _db.PurchaseOrder.AddAsync(model);

                var product = _db.Product.FirstOrDefault(x => x.ProductId == model.ProductId);
                product.QuantityInStock += model.Quantity;
                _db.Product.Update(product);

                await _db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
