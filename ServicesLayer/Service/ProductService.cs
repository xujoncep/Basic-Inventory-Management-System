using DataAccessLayer.IRepository;
using DataAccessLayer.Models;
using ServicesLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _pRepo;
        public ProductService(IProductRepository pRepo)
        {
            _pRepo = pRepo;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            var data = await _pRepo.GetAllProduct();
            return data;
        }
        public async Task<Product> GetProductById(int ProductId)
        {
            var data = await _pRepo.GetProductById(ProductId);
            return data;
        }
        public async Task<bool> Create(Product model)
        {
            var data = await _pRepo.Create(model);
            return data;
        }
        public async Task<bool> Edit(Product model)
        {
            var data = await _pRepo.Edit(model);
            return data;
        }
        public async Task<bool> IsProductExist(int ProductId, string ProductName)
        {
            return await _pRepo.IsProductExist(ProductId, ProductName);
        }
    }
}
