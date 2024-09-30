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
    public class ProductRepository: IProductRepository
    {
        private readonly IMSDbContext _db;
        public ProductRepository(IMSDbContext db)
        {
            _db = db;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var data = await (from p in _db.Product
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
                              }).ToListAsync();
            return data;
        }
        public async Task<Product> GetProductById(int productId)
        {
            var data = await _db.Product.FindAsync(productId);
            return data;
        }
        public async Task<bool> Create(Product model)
        {
            try
            {
                await _db.Product.AddAsync(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> Edit(Product model)
        {
            try
            {
                _db.Product.Update(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> IsProductExist(int ProductId, string ProductName)
        {
            if (ProductId > 0)
            {
                return await _db.Product.AnyAsync(x => x.ProductId != ProductId && x.ProductName == ProductName);
            }
            else
            {
                return await _db.Product.AnyAsync(x => x.ProductName == ProductName);
            }
        }
    }
}
