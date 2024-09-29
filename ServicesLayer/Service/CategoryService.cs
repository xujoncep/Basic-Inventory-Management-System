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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _catRepo;

        public CategoryService(ICategoryRepository catRepo)
        {
            _catRepo = catRepo;
        }


        public async Task<List<Category>> GetAllCetegory()
        {
            var data = await _catRepo.GetAllCetegory();
            return data;
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            var data = await _catRepo.GetCategoryById(CategoryId);
            return data;
        }
        public async Task<bool> Create(Category model)
        {
            var data = await _catRepo.Create(model);
            return data;
        }
        public async Task<bool> Edit(Category model)
        {
            var data = await _catRepo.Edit(model);
            return data;
        }
    }
}
