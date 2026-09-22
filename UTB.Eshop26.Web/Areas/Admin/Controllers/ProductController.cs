using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Enums;

namespace UTB.Eshop26.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class ProductController : Controller
    {
        IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // GET: /<controller>/Select
        public IActionResult Select()
        {
            IList<Product> products = _productAppService.SelectAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productAppService.Create(product);

                return RedirectToAction(nameof(ProductController.Select));
            }

            return View(product);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = _productAppService.Delete(id);

            if (deleted)
            {
                return RedirectToAction(nameof(ProductController.Select));
            }
            else
                return NotFound();
        }
    }
}
