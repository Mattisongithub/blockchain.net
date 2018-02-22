using System;
using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Utils
{
    class Encryption
    {
        public static string Encrypt(String data)
        {
            string encrypted = data;



            return encrypted;
        }

        public static string SHA256(String data)
        {
            SHA256Managed sha256 = new SHA256Managed();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
            foreach (byte singleByte in bytes)
            {
                stringBuilder.Append(singleByte.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public static string SHA512(String data)
        {
            SHA512Managed sha256 = new SHA512Managed();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));
            foreach (byte singleByte in bytes)
            {
                stringBuilder.Append(singleByte.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

    }
}
