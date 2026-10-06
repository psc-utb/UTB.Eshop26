using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;

namespace UTB.Eshop.Application.Implementation
{
    public class OrderItemAppService : IOrderItemAppService
    {
        IOrderItemRepository _orderItemRepository;
        IOrderRepository _orderRepository;

        public OrderItemAppService(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        public IList<OrderItem> Select()
        {
            return _orderItemRepository.GetAllWithProductsOrdersUsers().ToList();
        }

        public void Create(OrderItem orderItem)
        {
            Order? order = _orderRepository.GetById(orderItem.OrderID);
            if (order != null)
            {
                order.TotalPrice += orderItem.Price;
                _orderItemRepository.Add(orderItem);
            }
        }
    }
}
