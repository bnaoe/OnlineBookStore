using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository: IRepositoryAsync<CoverType>
    {
        void Update(CoverType coverType);
    }
}
