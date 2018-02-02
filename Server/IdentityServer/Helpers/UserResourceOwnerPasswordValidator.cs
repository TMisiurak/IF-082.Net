using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class UserResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUnitOfWork DataBase;

        public UserResourceOwnerPasswordValidator(IUnitOfWork uow)
        {
            DataBase = uow;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                //get your user model from db (by username - in my case its email)
                User user = await DataBase.Users.GetByEmail(context.UserName);
                Role role = await DataBase.Roles.GetById(user.RoleId);

                if (user != null)
                {
                    if (ValidationService.ValidatePassword(user.Password, context.Password))
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
        public static Claim[] GetUserClaims(User user, Role role)
        {
            return new Claim[]
            {
            new Claim("user_id", user.Id.ToString() ?? ""),
            //new Claim(JwtClaimTypes.Name, user.FullName  ?? ""),
            //new Claim(JwtClaimTypes.Email, user.Email  ?? ""),

            //roles
            new Claim(JwtClaimTypes.Role, role.Name)
            };
        }
    }
}
