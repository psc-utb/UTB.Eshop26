using System;
using System.Collections.Generic;
using System.Text;

namespace UTB.Eshop.Domain.Entities.Interfaces.Repository
{
    public interface IOrderRepository : IRepository<Order, int>
    {
        IEnumerable<Order> GetAllWithUsers();
    }
}
