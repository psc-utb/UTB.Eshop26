using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Domain.Enums;

namespace UTB.Eshop.Domain.Entities.Interfaces.Managers
{
    public interface IAccountManager<TKey> where TKey : notnull
    {
        Task<string[]> Create(IUser<TKey> user, string password, params Roles[] roles);

        Task<bool> Login(string username, string password);
        Task Logout();
    }
}
