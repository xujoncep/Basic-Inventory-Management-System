using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(int SupplierId);
        Task<bool> Create(Supplier model);
        Task<bool> Edit(Supplier model);
        Task<bool> IsSupplierCodeExist(int SupplierId, string SupplierCode);
    }
}
