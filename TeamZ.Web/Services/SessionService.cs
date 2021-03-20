using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TeamZ.Shared;

namespace TeamZ.Web
{
    public class SessionService
    {
        public string LoggedInUser { get; private set; } = null;
        public string SessionKey { get; private set; } = null;
        public DateTime LoginTime { get; private set; }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void LoginUser(string username, string newKey)
        {
            LoggedInUser = username;
            SessionKey = newKey;
            LoginTime = DateTime.Now;
            NotifyStateChanged();
        }

        public void LogOutUser()
        {
            LoggedInUser = null;
            SessionKey = null;
        }

        public double CheckTimeLoggedOn()
        {
            TimeSpan timeLoggedOn = LoginTime - DateTime.Now;
            return timeLoggedOn.TotalMinutes;
        }

        public string GenerateSessionKey()
        {
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789!?#$%@*&";
            Random rng = new Random();

            var chars = Enumerable.Range(0, 32)
                .Select(x => pool[rng.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        public string GetSaltString()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string saltString = Encoding.ASCII.GetString(salt);
            return saltString;
        }

        public string Hasher(string salt, string str)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: str,
                salt: Encoding.ASCII.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
    }
}
