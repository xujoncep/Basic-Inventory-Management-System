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
    public class CategoryRepository: ICategoryRepository
    {
        private readonly IMSDbContext _db;

        public CategoryRepository(IMSDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAllCetegory()
        {
            var data = await _db.Category.ToListAsync();
            return data;
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            var data = await _db.Category.FindAsync(CategoryId);
            return data;
        }
        public async Task<bool> Create(Category model)
        {
            try
            {
                await _db.Category.AddAsync(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> Edit(Category model)
        {
            try
            {
                _db.Category.Update(model);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
