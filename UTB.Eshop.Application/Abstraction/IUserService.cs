using System.Security.Claims;
using UTB.Eshop.Domain.Entities.Interfaces;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IUserService
    {
        Task<IUser<int>?> GetCurrentUser(ClaimsPrincipal claimsPrincipal);
    }
}
