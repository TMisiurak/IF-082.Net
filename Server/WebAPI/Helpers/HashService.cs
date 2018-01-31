using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public static class HashService
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
    }
}
