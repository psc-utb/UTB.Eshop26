using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using UTB.Eshop.Domain.Entities.Interfaces;
using UTB.Eshop.Domain.Entities.Interfaces.Managers;
using UTB.Eshop.Domain.Enums;
using UTB.Eshop.Infrastructure.Identity;

namespace UTB.Eshop.Infrastructure.Managers
{
    public class AccountIdentityManager : IAccountManager<int>
    {
        UserManager<User> userManager;
        SignInManager<User> sigInManager;

        public AccountIdentityManager(UserManager<User> userManager, SignInManager<User> sigInManager)
        {
            this.userManager = userManager;
            this.sigInManager = sigInManager;
        }


        public async Task<string[]> Create(IUser<int> userIn, string password, params Roles[] roles)
        {
            User user = new User()
            {
                UserName = userIn.UserName,
                FirstName = userIn.FirstName,
                LastName = userIn.LastName,
                Email = userIn.Email,
                PhoneNumber = userIn.PhoneNumber
            };

            string[] errors = null;

            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                foreach (var role in roles)
                {
                    var resultRole = await userManager.AddToRoleAsync(user, role.ToString());

                    if (resultRole.Succeeded == false)
                    {
                        for (int i = 0; i < result.Errors.Count(); ++i)
                            result.Errors.Append(result.Errors.ElementAt(i));
                    }
                }
            }

            if (result.Errors != null && result.Errors.Count() > 0)
            {
                errors = new string[result.Errors.Count()];
                for (int i = 0; i < result.Errors.Count(); ++i)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }
            }

            return errors;
        }


        public async Task<bool> Login(string username, string password)
        {
            var result = await sigInManager.PasswordSignInAsync(username, password, true, true);
            return result.Succeeded;
        }

        public Task Logout()
        {
            return sigInManager.SignOutAsync();
        }
    }
}
