using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookStore.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepositoryAsync<OrderHeader>
    {
        void Update(OrderHeader obj);
    }
}
