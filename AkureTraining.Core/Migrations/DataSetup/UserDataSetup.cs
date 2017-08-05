using AkureTraining.Core.Context;
using Microsoft.AspNet.Identity;
using SmartWr.WebFramework.Library.Infrastructure.Factory;
using SmartWr.WebFramework.Library.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkureTraining.Core.Migrations.DataSetup
{
    public static class UserDataSetup
    {
        public static void CreateAdminUsers(AkureTrainingDbContext context)
        {
            const string password = "micr0s0ft_";

            var users = new string[]
            {
                "system@smartware.ng",
                "administrator@smartware.ng",
                "support@smartware.ng",
            };

            var applicationRoleManager = IdentityFactory.CreateRoleManager(context);
            var applicationUserManager = IdentityFactory.CreateUserManager(context);

            Array.ForEach(users, customerID =>
            {
                IdentityResult identityResult;

                var user = applicationUserManager.FindByNameAsync(customerID).Result;

                if (user == null)
                {
                    user = new ApplicationIdentityUser { UserName = customerID, Email = customerID };
                    identityResult = applicationUserManager.CreateAsync(user, password).Result;

                    if (!identityResult.Succeeded)
                        identityResult = applicationUserManager.SetLockoutEnabledAsync(user.Id, false).Result;
                }

                var roleResult = applicationRoleManager.RoleExistsAsync("ADMIN");

                if (!roleResult.Result)
                    identityResult = applicationRoleManager.CreateAsync(new ApplicationIdentityRole { Name = "ADMIN" }).Result;

                var isInRole = applicationUserManager.IsInRoleAsync(user.Id, "ADMIN");

                if (user != null && !isInRole.Result)
                    identityResult = applicationUserManager.AddToRoleAsync(user.Id, "ADMIN").Result;

                //validate Email
                if (user != null)
                {
                    var token = applicationUserManager.GenerateEmailConfirmationToken(user.Id);
                    applicationUserManager.ConfirmEmail(user.Id, token);
                }
            });
        }
    }
}
