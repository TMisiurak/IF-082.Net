using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
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
        private ClinicContext _db;

        public UserProfileService(ClinicContext db)
        {
            _db = db;
        }

        //Get user profile date in terms of claims when calling /connect/userinfo
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "sub");

            if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
            {
                //get user from db (find user by user id)
                User user = _db.Users.Where(x => x.Id == long.Parse(userId.Value)).FirstOrDefault();
                string role = _db.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault().Name;

                // issue the claims for the user
                if (user != null)
                {
                    var claims = ResourceOwnerValidator.GetUserClaims(user, role);

                    context.IssuedClaims = claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                }
            }
        }

        //check if user account is active.
        public async Task IsActiveAsync(IsActiveContext context)
        {
            try
            {
                //get subject from context (set in ResourceOwnerPasswordValidator.ValidateAsync),
                var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");

                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    User user = _db.Users.Where(x => x.Id == long.Parse(userId.Value)).FirstOrDefault();

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
