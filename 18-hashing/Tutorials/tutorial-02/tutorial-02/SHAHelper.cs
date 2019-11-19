using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace hashing
{
    class SHAHelper
    {
        public static string Hashsha1(string source)
        {
            var sb = new StringBuilder();
            using (SHA1 sha = new SHA1Managed())
            {
                var computehash = sha.ComputeHash(Encoding.UTF8.GetBytes(source));
                foreach (var b in computehash)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }

        public static string Generatedsalt()
        {
            return Guid.NewGuid().ToString().Substring(0, 10);

        }
    }
}
