using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProduct();
        Task<Product> GetProductById(int productId);
        Task<bool> Create(Product model);
        Task<bool> Edit(Product model);
        Task<bool> IsProductExist(int ProductId, string ProductName);
    }
}
