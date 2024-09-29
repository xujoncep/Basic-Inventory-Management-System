using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCetegory();
        Task<Category> GetCategoryById(int CategoryId);
        Task<bool> Create(Category model);
        Task<bool> Edit(Category model);
        Task<bool> IsCategoryExist(int CategoryId, string CategoryName);
    }
}
