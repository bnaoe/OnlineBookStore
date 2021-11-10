using OnlineBookStore.DataAccess.Data;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository
{
    public class CoverTypeRepository: RepositoryAsync<CoverType>, ICoverTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(CoverType coverType)
        {
            var objInDb = _db.CoverTypes.FirstOrDefault(c => c.Id == coverType.Id);

            if (objInDb != null)
            {
                objInDb.Name = coverType.Name;
            }

        }
    }
}
