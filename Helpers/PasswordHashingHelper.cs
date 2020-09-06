using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore_api_sample.Helpers
{
    public class PasswordHashingHelper
    {
        public string onewayHashing(string password , string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                                     password: password,
                                     salt: Encoding.UTF8.GetBytes(salt),
                                     prf: KeyDerivationPrf.HMACSHA512,
                                     iterationCount: 10000,
                                     numBytesRequested: 256 / 8);

            return Convert.ToBase64String(valueBytes);
        }

    }
}
