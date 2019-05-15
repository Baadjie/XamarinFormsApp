using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace XamarinFormsWebAPI.Model
{
    public class SaltPassword
    {
        //Funtion to create a Random salt String
        public static byte[] GetRandomSalt(int length)
        {


            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        //function to create Password with Salt
        public static byte[] saltHashPassword(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltBytes = new byte[password.Length + salt.Length];
            for (int i = 0; i < password.Length; i++)
                plainTextWithSaltBytes[i] = password[i];
            for (int i = 0; i < salt.Length; i++)
                plainTextWithSaltBytes[password.Length + i] = salt[i];

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }
    }
}
