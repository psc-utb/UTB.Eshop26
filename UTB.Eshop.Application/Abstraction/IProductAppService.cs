using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IProductAppService
    {
        IList<Product> SelectAll();
        void Create(Product product);
        bool Delete(int id);
    }
}

