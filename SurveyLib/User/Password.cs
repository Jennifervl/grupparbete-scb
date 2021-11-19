using System;
using System.Security.Cryptography;

namespace SurveyLib
{
    public class Password
    {
        string salt;
        string hashedPassword;

        public string Salt { get => salt; }
        public string HashedPassword { get => hashedPassword; }

        public Password(string password)
        {
            this.salt = CreateRandomSalt();

            this.hashedPassword = HashPassword(password, this.salt, 10101, 70);
        }

        private string CreateRandomSalt()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        private string HashPassword(string password, string salt, int nIterations, int nHash)
        {
            var saltBytes = Convert.FromBase64String(salt);
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(nHash));
            }
        }
    }
}
