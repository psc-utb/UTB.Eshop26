using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;

namespace UTB.Eshop.Application.Implementation
{
    public class HomeService : IHomeService
    {
        IProductAppService _productAppService;
        ICarouselAppService _carouselAppService;

        public HomeService(IProductAppService productAppService,
                           ICarouselAppService carouselAppService)
        {
            _productAppService = productAppService;
            _carouselAppService = carouselAppService;
        }

        public IndexViewModel GetIndexViewModel()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Products = _productAppService.SelectAll();
            viewModel.Carousels = _carouselAppService.SelectAll();
            return viewModel;
        }
    }
}
