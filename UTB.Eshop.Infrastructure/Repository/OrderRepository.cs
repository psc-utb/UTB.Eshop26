using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(EshopDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Order> GetAllWithUsers()
        {
            return dbSet.Include(o => o.User).ToList();
        }
    }
}
