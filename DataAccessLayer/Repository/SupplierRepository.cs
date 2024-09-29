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
    public class SupplierRepository: ISupplierRepository
    {
        private readonly IMSDbContext _db;

        public SupplierRepository(IMSDbContext db)
        {
            _db = db;
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
            var data = await _db.Supplier.ToListAsync();
            return data;
        }

        public async Task<Supplier> GetSupplierById(int SupplierId)
        {
            var data = await _db.Supplier.FindAsync(SupplierId);
            return data;
        }

        public async Task<bool> Create(Supplier model)
        {
            try
            {
                await _db.Supplier.AddAsync(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Edit(Supplier model)
        {
            try
            {
                _db.Supplier.Update(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> IsSupplierCodeExist(int SupplierId, string SupplierCode)
        {
            if (SupplierId > 0)
            {
                return await _db.Supplier.AnyAsync(x => x.SupplierId != SupplierId && x.SupplierCode == SupplierCode);
            }
            else
            {
                return await _db.Supplier.AnyAsync(x => x.SupplierCode == SupplierCode);
            }
        }
    }
}
