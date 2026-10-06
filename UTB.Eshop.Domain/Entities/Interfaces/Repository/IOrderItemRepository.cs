using System;
using System.Collections.Generic;
using System.Text;

namespace UTB.Eshop.Domain.Entities.Interfaces.Repository
{
    public interface IOrderItemRepository : IRepository<OrderItem, int>
    {
        IEnumerable<OrderItem> GetAllWithProductsOrdersUsers();
    }
}
