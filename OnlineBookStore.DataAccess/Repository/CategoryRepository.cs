using OnlineBookStore.DataAccess.Data;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository
{
    public class CategoryRepository: RepositoryAsync<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objInDb = _db.Categories.FirstOrDefault(c => c.Id == category.Id);

            if (objInDb != null)
            {
                objInDb.Name = category.Name;
            }

        }
    }
}
