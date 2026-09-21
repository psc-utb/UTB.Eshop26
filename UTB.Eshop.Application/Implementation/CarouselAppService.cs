using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;

namespace UTB.Eshop.Application.Implementation
{
    public class CarouselAppService : ICarouselAppService
    {
        ICarouselRepository _carouselRepository;

        public CarouselAppService(ICarouselRepository carouselRepository)
        {
            _carouselRepository = carouselRepository;
        }

        public IList<Carousel> SelectAll()
        {
            return _carouselRepository.GetAll().ToList();
        }
    }
}
