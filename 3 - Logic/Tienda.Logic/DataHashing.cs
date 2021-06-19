    using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Logic
{
    public class DataHashing
    {
        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public string ComputeHash(string stringToHash, string salt)
        {
            byte[] bytesToHash = Encoding.UTF8.GetBytes(stringToHash);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, saltBytes, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

    } 
}

        //public string[] ComputeHash(string stringToHash)
        //{
        //    byte[] bytesToHash = Encoding.UTF8.GetBytes(stringToHash);
        //    //Salt 
        //    //int minSaltSize = 4;
        //    //int maxSaltSize = 8;

        //    // Generate a random number for the size of the salt.
        //    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        //    //Random random = new Random();
        //    //int saltSize = random.Next(minSaltSize, maxSaltSize);

        //    var bytes = new byte[128 / 8];
        //    rng.GetNonZeroBytes(bytes);
        //    byte[] saltBytes = bytes;
        //    // Allocate a byte array, which will hold the salt.

        //    // Initialize a random number generator.

        //    // Fill the salt with cryptographically strong byte values.
        
        //    // Convert plain text into a byte array.
        //    byte[] plainTextBytes = Encoding.UTF8.GetBytes(stringToHash);

        //    // Allocate array, which will hold plain text and salt.
        //    byte[] plainTextWithSaltBytes =
        //            new byte[plainTextBytes.Length + saltBytes.Length];

        //    // Copy plain text bytes into resulting array.
        //    for (int i = 0; i<plainTextBytes.Length; i++)
        //        plainTextWithSaltBytes[i] = plainTextBytes[i];

        //    // Append salt bytes to the resulting array.
        //    for (int i = 0; i<saltBytes.Length; i++)
        //        plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

        //    //Hash 
        //    string[] returns = new string[2];
        //    returns[0] = salt.ToString();
        //    var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
        //    returns[1] = Convert.ToBase64String(byteResult.GetBytes(24));
        //    return returns;
        //}
        //public string[] ComputeHash(byte[] bytesToHash, byte[]hash)
        //{
        //    //Salt 
        //    var bytes = new byte[128 / 8];
        //    var rng = new RNGCryptoServiceProvider();
        //    rng.GetBytes(bytes);
        //    byte[] salt = bytes;
        //    //Hash 
        //    string[] returns = new string[2];
        //    returns[0] = salt.ToString();
        //    var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
        //    returns[1] = Convert.ToBase64String(byteResult.GetBytes(24));
        //    return returns;
            //bytes = new byte[128 / 8];
            ////rng = new RNGCryptoServiceProvider();
            //rng.GetBytes(bytes);
            ////Return Value
            //return session.ComputeHash(Encoding.UTF8.GetBytes(Console.ReadLine()), Encoding.UTF8.GetBytes(newSalt));
        
        //public string NewSalt()
        //{
        //    var bytes = new byte[128 / 8];
        //    var rng = new RNGCryptoServiceProvider();
        //    rng.GetBytes(bytes);
        //    return Convert.ToBase64String(bytes);
        //}
        //public string ComputeHash(byte[] bytesToHash, byte[] salt)
        //{
        //    var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
        //    return Convert.ToBase64String(byteResult.GetBytes(24));
        //}
        //public string NewSalt()
        //{
        //    var bytes = new byte[128 / 8];
        //    var rng = new RNGCryptoServiceProvider();
        //    rng.GetBytes(bytes);
        //    return Convert.ToBase64String(bytes);
        //}
    

