using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UTB.Eshop.Domain.Entities.Interfaces;
using UTB.Eshop.Domain.Entities.Interfaces.Repository;
using UTB.Eshop.Infrastructure.Database;
using UTB.Eshop.Infrastructure.Identity;

namespace UTB.Eshop.Infrastructure.Repository
{
    public class UserRepository : Repository<IUser<int>, int>, IUserRepository
    {
        UserManager<User> userManager;

        public UserRepository(EshopDbContext dbContext, UserManager<User> userManager) : base(dbContext)
        {
            this.userManager = userManager;
        }

        public async Task<IUser<int>?> FindUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<IUser<int>?> FindUserByUsername(string username)
        {
            return await userManager.FindByNameAsync(username);
        }

        public async Task<IUser<int>?> GetCurrentUser(ClaimsPrincipal principal)
        {
            return await userManager.GetUserAsync(principal);
        }

        public Task<IList<string>> GetUserRoles(IUser<int> user)
        {
            return userManager.GetRolesAsync(user as User);
        }
    }
}
