using OnlineBookStore.DataAccess.Data;
using OnlineBookStore.DataAccess.Repository.IRepository;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository
{
    public class CompanyRepository : RepositoryAsync<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            //why is this statement different than other Repository
            _db.Update(company);     

        }
    }
}
