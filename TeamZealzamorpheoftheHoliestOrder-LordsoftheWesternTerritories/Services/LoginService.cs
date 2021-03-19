using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TeamZealzamorpheoftheHoliestOrder_LordsoftheWesternTerritories.Services
{
    public class LoginService
    {
        public Tuple<string, string> SaltAndHash(string password, string saltString = null)
        {
            string savedSalt;
            if (saltString is null)
            {
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                savedSalt = Encoding.ASCII.GetString(salt);
            } else
            {
                savedSalt = saltString;
            }
            
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.ASCII.GetBytes(savedSalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return Tuple.Create(hashed, savedSalt);
        }

        public string GenerateSessionKey()
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789!?#$%@*&";
            Random rng = new Random();

            var chars = Enumerable.Range(0, 32)
                .Select(x => pool[rng.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }
    }
}
