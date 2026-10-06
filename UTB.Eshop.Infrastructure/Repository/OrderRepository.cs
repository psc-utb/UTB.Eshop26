using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;
using UTB.Eshop.Infrastructure.Identity;

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

        public IEnumerable<Order> GetAllByUserWithAllIncluded(int userId)
        {
            return dbSet.Where(o => o.UserId == userId)
                                            .Include(o => o.User)
                                            .Include(o => o.OrderItems)
                                               .ThenInclude(oi => oi.Product)
                                            .ToList();
        }
    }
}
