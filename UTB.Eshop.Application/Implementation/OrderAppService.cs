using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;

namespace UTB.Eshop.Application.Implementation
{
    public class OrderAppService : IOrderAppService
    {
        IOrderRepository _orderRepository;

        public OrderAppService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IList<Order> Select()
        {
            return _orderRepository.GetAllWithUsers().ToList();
        }

        public IList<Order> SelectForUser(int userId)
        {
            return _orderRepository.GetAllByUserWithAllIncluded(userId).ToList();
        }

        public void Create(Order order)
        {
            _orderRepository.Add(order);
        }
    }
}
