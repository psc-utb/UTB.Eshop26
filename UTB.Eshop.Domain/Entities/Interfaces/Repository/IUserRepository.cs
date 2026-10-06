using System.Security.Claims;

namespace UTB.Eshop.Domain.Entities.Interfaces.Repository
{
    public interface IUserRepository : IRepository<IUser<int>, int>
    {
        Task<IUser<int>?> FindUserByUsername(string username);
        Task<IUser<int>?> FindUserByEmail(string email);
        Task<IUser<int>?> GetCurrentUser(ClaimsPrincipal principal);
        Task<IList<string>> GetUserRoles(IUser<int> user);
    }
}
