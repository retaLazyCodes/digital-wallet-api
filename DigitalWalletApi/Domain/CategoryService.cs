using System.Collections.Generic;
using System.Linq;
using DigitalWalletApi.Data;

namespace DigitalWalletApi.Domain
{
    public class CategoryService : ICategoryService
    {
        private readonly DigitalWalletDbContext _db;

        public CategoryService(DigitalWalletDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public bool Add(string description)
        {
            var category = _db.Categories.SingleOrDefault(c => c.Description == description);
            if (category != null) {
                return false;
            }
            
            var newCategory = new Category
            {
                Description = description
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var category = _db.Categories.SingleOrDefault(t => t.Id == id);
            if (category != null) {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}