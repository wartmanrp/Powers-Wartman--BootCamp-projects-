// Copyright (c) 2014 Computer Technology Solutions, Inc.  ALL RIGHTS RESERVED
// http://www.askcts.com
// Author: CTS, Inc.
// Product: Cts.Venture.Service
// Version: 1.0.1
// 
// ********************************************************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cts.Venture.Common.Helpers
{
   /// <summary>
   /// The class implements hashing algorithm.
   /// </summary>
   public class HashHelper
   {
      /// <summary>
      /// Returns hash value for the plain text.
      /// </summary>
      /// <param name="plainText">Text to hash.</param>
      /// <param name="hashAlgorithm">Hashing algorithm types defined in <c>HashAlgorithms</c> enum.</param>
      /// <param name="saltBytes">Salt for hashing</param>
      /// <returns>Hashed value from plain text.</returns>
      public static string GetHash(string plainText, HashAlgorithms hashAlgorithm, byte[] saltBytes)
      {
         // If salt is not specified, generate it on the fly.
         saltBytes = GenerateSalt(saltBytes);

         // Convert plain text into a byte array.
         byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

         // Allocate array, which will hold plain text and salt.
         byte[] plainTextWithSaltBytes =
                 new byte[plainTextBytes.Length + saltBytes.Length];

         // Copy plain text bytes into resulting array.
         for (int i = 0; i < plainTextBytes.Length; i++)
            plainTextWithSaltBytes[i] = plainTextBytes[i];

         // Append salt bytes to the resulting array.
         for (int i = 0; i < saltBytes.Length; i++)
            plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];

         // Because we support multiple hashing algorithms, we must define
         // hash object as a common (abstract) base class. We will specify the
         // actual hashing algorithm class later during object creation.
         HashAlgorithm hash = GetHashAlgorithm(hashAlgorithm);

         // Compute hash value of our plain text with appended salt.
         byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

         // Create array which will hold hash and original salt bytes.
         byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                             saltBytes.Length];

         // Copy hash bytes into resulting array.
         for (int i = 0; i < hashBytes.Length; i++)
            hashWithSaltBytes[i] = hashBytes[i];

         // Append salt bytes to the result.
         for (int i = 0; i < saltBytes.Length; i++)
            hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

         // Convert result into a base64-encoded string.
         string hashValue = Convert.ToBase64String(hashWithSaltBytes);

         // Return the result.
         return hashValue;
      }

      /// <summary>
      /// Initiates appropriate hashing algorithm implementation.
      /// </summary>
      /// <param name="hashAlgorithm">Defines which hashing algorithm to use.</param>
      /// <returns><see cref="System.Security.Cryptography.HashAlgorithm"/> to use for hash.</returns>
      private static HashAlgorithm GetHashAlgorithm(HashAlgorithms hashAlgorithm)
      {
         HashAlgorithm hash;
         // Initialize appropriate hashing algorithm class.
         switch (hashAlgorithm)
         {
            case HashAlgorithms.SHA1:
               hash = new SHA1Managed();
               break;

            case HashAlgorithms.SHA256:
               hash = new SHA256Managed();
               break;

            case HashAlgorithms.SHA384:
               hash = new SHA384Managed();
               break;

            case HashAlgorithms.SHA512:
               hash = new SHA512Managed();
               break;

            default:
               hash = new MD5CryptoServiceProvider();
               break;
         }
         return hash;
      }

      /// <summary>
      /// Calculates salt for hash algorithm from <c>saltBytes</c>.
      /// </summary>
      /// <param name="saltBytes">Base salt value.</param>
      /// <returns><c>byte[]</c> value used for hashing.</returns>
      private static byte[] GenerateSalt(byte[] saltBytes)
      {
         if (saltBytes == null)
         {
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;

            // Generate a random number for the size of the salt.
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            // Allocate a byte array, which will hold the salt.
            saltBytes = new byte[saltSize];

            // Initialize a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Fill the salt with cryptographically strong byte values.
            rng.GetNonZeroBytes(saltBytes);
         }
         return saltBytes;
      }

      /// <summary>
      /// Determines if two string (one hashed and other plain text) are same.
      /// </summary>
      /// <param name="plainText">Plain text value to match against hashed value.</param>
      /// <param name="hashAlgorithm">Hash algorithm to use.</param>
      /// <param name="hashValue">Hashed value that will be used to match against.</param>
      /// <returns>true - if the two values matches.</returns>
      public static bool IsMatch(string plainText, HashAlgorithms hashAlgorithm, string hashValue)
      {
         // Convert base64-encoded hash value into a byte array.
         byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

         // We must know size of hash (without salt).
         int hashSizeInBits, hashSizeInBytes;

         // Size of hash is based on the specified algorithm.
         switch (hashAlgorithm)
         {
            case HashAlgorithms.SHA1:
               hashSizeInBits = 160;
               break;

            case HashAlgorithms.SHA256:
               hashSizeInBits = 256;
               break;

            case HashAlgorithms.SHA384:
               hashSizeInBits = 384;
               break;

            case HashAlgorithms.SHA512:
               hashSizeInBits = 512;
               break;

            default: // Must be MD5
               hashSizeInBits = 128;
               break;
         }

         // Convert size of hash from bits to bytes.
         hashSizeInBytes = hashSizeInBits / 8;

         // Make sure that the specified hash value is long enough.
         if (hashWithSaltBytes.Length < hashSizeInBytes)
            return false;

         // Allocate array to hold original salt bytes retrieved from hash.
         byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                     hashSizeInBytes];

         // Copy salt from the end of the hash to the new array.
         for (int i = 0; i < saltBytes.Length; i++)
            saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

         // Compute a new hash string.
         string expectedHashString =
                     GetHash(plainText, hashAlgorithm, saltBytes);

         // If the computed hash matches the specified hash,
         // the plain text value must be correct.
         return (hashValue == expectedHashString);
      }
   }

   /// <summary>
   /// Supported hashing algorithms.
   /// </summary>
   public enum HashAlgorithms
   {
      /// <summary>
      /// The hash size for the SHA1 algorithm is 160 bits. Least secure.
      /// </summary>
      SHA1,

      /// <summary>
      /// The hash size for the SHA256 algorithm is 256 bits.
      /// </summary>
      SHA256,

      /// <summary>
      /// The hash size for the SHA384 algorithm is 384 bits
      /// </summary>
      SHA384,

      /// <summary>
      /// The hash size for the SHA384 algorithm is 512 bits
      /// </summary>
      SHA512
   }
}
