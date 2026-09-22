using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.Records;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities.Interfaces;
using UTB.Eshop.Domain.Entities.Interfaces.Managers;
using UTB.Eshop.Domain.Enums;

namespace UTB.Eshop.Application.Implementation
{
    public class AccountService<TKey> : IAccountService where TKey : notnull
    {
        IAccountManager<TKey> _accountManager;

        public AccountService(IAccountManager<TKey> accountManager)
        {
            _accountManager = accountManager;
        }


        public async Task<string[]> Register(RegisterViewModel vm, params Roles[] roles)
        {
            IUser<TKey> user = new UserRecord<TKey>
            {
                UserName = vm.Username,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.Phone
            };

            var errors = await _accountManager.Create(user, vm.Password, roles);
            return errors;
        }


        public async Task<bool> Login(LoginViewModel vm)
        {
            return await _accountManager.Login(vm.Username, vm.Password);
        }

        public Task Logout()
        {
            return _accountManager.Logout();
        }
    }
}
