using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Infrastructure.Repository
{
    public class CarouselRepository : Repository<Carousel, int>, ICarouselRepository
    {
        public CarouselRepository(EshopDbContext context) : base(context)
        {
        }
    }
}
