using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public class HashedLogic
    {
        private readonly IUserService _userService;

        public HashedLogic(IUserService userService)
        {
            _userService = userService;
        }

        public static string HashPassword(string inputPass)
        {
            byte[] salt = new byte[128 / 8];

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: inputPass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public bool CheckedHashedPassword(string userPassword, string userEmail)
        {
            var user = _userService.GetUserByEmail(userEmail);
            var hashedPassword = HashPassword(userPassword);

            if (user.Password.Equals(hashedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
