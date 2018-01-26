using BLL.Interfaces;
using DAL.EF;
using DAL.Entities;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace IdentityServer
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        private readonly ClinicContext _db;
        private readonly IUserService _userService;

        public ResourceOwnerValidator(ClinicContext db, IUserService userService)
        {
            _db = db;
            _userService = userService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                //get your user model from db (by username - in my case its email)
                User user = _db.Users.Where(x => x.Email == context.UserName).FirstOrDefault();
                string role = _db.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault().Name;
                var hashedLogic = new HashedLogic(_userService);

                if (user != null)
                {
                    if (hashedLogic.CheckedHashedPassword(context.Password, context.UserName))
                    {
                        context.Result = new GrantValidationResult(
                            subject: user.Id.ToString(),
                            authenticationMethod: "custom",
                            claims: GetUserClaims(user, role));

                        return;
                    }

                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Incorrect password");
                    return;
                }
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "User does not exist.");
                return;
            }
            catch (Exception)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Invalid username or password");
            }
        }

        //build claims array from user data
        public static Claim[] GetUserClaims(User user, string role)
        {
            return new Claim[]
            {
            new Claim("user_id", user.Id.ToString() ?? ""),
            new Claim(JwtClaimTypes.Name, user.FullName  ?? ""),
            new Claim(JwtClaimTypes.Email, user.Email  ?? ""),

            //roles
            new Claim(JwtClaimTypes.Role, role)
            };
        }
    }
}
