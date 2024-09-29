using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService
{
    public interface ISupplierService
    {
        Task<List<Supplier>> GetAllSupplier();
        Task<Supplier> GetSupplierById(int SupplierId);
        Task<bool> Create(Supplier model);
        Task<bool> Edit(Supplier model);
    }
}
