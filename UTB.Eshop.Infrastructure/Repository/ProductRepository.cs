using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(EshopDbContext context) : base(context)
        {
        }
    }
}
