using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;

namespace UTB.Eshop.Application.Implementation
{
    public class ProductAppService : IProductAppService
    {
        IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> SelectAll()
        {
            return _productRepository.GetAll().ToList();
        }
    }
}
