using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository: IRepositoryAsync<Company>
    {
        void Update(Company company);
    }
}
