using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Domain.Enums;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop26.Web.Areas.Customer.Controllers
{
    [Area(nameof(Customer))]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerOrdersController : Controller
    {

        IUserService _userService;
        IOrderAppService _orderService;

        public CustomerOrdersController(IUserService userService, IOrderAppService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            IUser<int>? currentUser = await _userService.GetCurrentUser(User);
            if (currentUser != null)
            {
                IList<Order> userOrders = _orderService.SelectForUser(currentUser.Id);
                return View(userOrders);
            }

            return NotFound();
        }
    }
}
