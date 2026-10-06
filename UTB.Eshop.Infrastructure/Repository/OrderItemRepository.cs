using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Infrastructure.Repository
{
    public class OrderItemRepository : Repository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(EshopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<OrderItem> GetAllWithProductsOrdersUsers()
        {
            return dbSet
                    .Include(oi => oi.Product)
                    .Include(oi => oi.Order)
                        .ThenInclude(o => o.User)
                    .OrderBy(oi => oi.Id)
                    .ToList();
        }
    }
}
