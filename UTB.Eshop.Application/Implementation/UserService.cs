using System.Security.Claims;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities.Interfaces;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;

namespace UTB.Eshop.Application.Implementation
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IUser<int>?> GetCurrentUser(ClaimsPrincipal claimsPrincipal)
        {
            return _userRepository.GetCurrentUser(claimsPrincipal);
        }
    }
}
