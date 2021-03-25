using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Omega.Ticket.Transversal
{
    public static class Cryptographic
    {
        public static byte[] GenerateSalt()
        {
            const int salLength = 32;
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[salLength];
                randomNumberGenerator.GetBytes(randomNumber);
                return randomNumber;
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            var ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static byte[] HashPasswordWidthSalt(byte[] toBeHashed, byte[] salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedHash = Combine(toBeHashed, salt);
                return sha256.ComputeHash(combinedHash);
            }
        }
    }
}
