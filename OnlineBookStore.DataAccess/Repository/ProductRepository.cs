using OnlineBookStore.DataAccess.Data;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository
{
    public class ProductRepository : RepositoryAsync<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objInDb = _db.Products.FirstOrDefault(c => c.Id == product.Id);

            if (objInDb != null)
            {
                if (product.ImageUrl!=null)
                {
                    objInDb.ImageUrl = product.ImageUrl;
                }

                objInDb.ISBN = product.ISBN;
                objInDb.Price = product.Price;
                objInDb.Price50 = product.Price50;
                objInDb.ListPrice = product.ListPrice;
                objInDb.Price100 = product.Price100;
                objInDb.Title = product.Title;
                objInDb.Description = product.Description;
                objInDb.CategoryId = product.CategoryId;
                objInDb.Author = product.Author;
                objInDb.CoverTypeId = product.CoverTypeId;

            }
        }
    }
}
