using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace IdentityServer
{
    public static class ValidationService
    {
        public static string HashPassword(string inputPassword)
        {
            byte[] salt = new byte[128 / 8];

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: inputPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword;
        }

        public static bool ValidatePassword(string userPassword, string inputPassword)
        {
            var hashedInputPassword = HashPassword(inputPassword);

            if (userPassword.Equals(hashedInputPassword))
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
