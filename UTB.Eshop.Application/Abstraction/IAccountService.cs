using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Enums;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IAccountService
    {
        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);

        Task<bool> Login(LoginViewModel vm);
        Task Logout();
    }
}
