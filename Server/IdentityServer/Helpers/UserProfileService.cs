using DAL.Entities;
using DAL.Interfaces;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class UserProfileService : IProfileService
    {
        private readonly IUnitOfWork DataBase;

        public UserProfileService(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        //Get user profile date in terms of claims when calling /connect/userinfo
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            bool result = Int32.TryParse(context.Subject.Claims.FirstOrDefault(x => x.Type == "sub").Value, out int userId);
            if (result && userId > 0)
            {
                //get user from db (find user by user id)
                User user = await DataBase.Users.GetById(userId);

                // issue the claims for the user
                if (user != null)
                {
                    Role role = await DataBase.Roles.GetById(user.RoleId);
                    var claims = UserResourceOwnerPasswordValidator.GetUserClaims(user, role);

                    context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                }
            }
        }

        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                bool result = Int32.TryParse(context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id").Value, out int userId);
                
                if (result && userId > 0)
                {
                    User user = await DataBase.Users.GetById(userId);

                    if (user != null)
                    {
                        if (true)
                        {
                            context.IsActive = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //handle error logging
            }
        }
    }
}
