using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;

namespace GABIZ.Base.Cryptography
{
    /// <summary>
    /// Class for implement some cryptography functions
    /// </summary>
    public class Crypto
    {
        /// <summary>
        /// Encrypts a string
        /// </summary>
        /// <param name="PlainTextBytes">Bytes to be encrypted</param>
        /// <param name="Password">Password to encrypt with</param>
        /// <param name="Salt">Salt to encrypt with</param>
        /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
        /// <param name="PasswordIterations">Number of iterations to do</param>
        /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
        /// <param name="KeySize">Can be 128, 192, or 256</param>
        /// <returns>An encrypted bytes</returns>
        public static byte[] Encrypt(
            byte[] PlainTextBytes,
            string Password,
            string Salt,
            string HashAlgorithm,
            int PasswordIterations,
            string InitialVector,
            int KeySize)
        {
            if ((Salt == null) || (Salt == "")) Salt = "Nextcom123";
            if ((HashAlgorithm == null) || (HashAlgorithm == "")) HashAlgorithm = "SHA1";
            if (PasswordIterations == 0) PasswordIterations = 2;
            if ((InitialVector == null) || (InitialVector == "") || (InitialVector.Length != 16)) InitialVector = "ANGh9M&op-*UL$W%";
            if ((KeySize != 128) && (KeySize != 192) && (KeySize != 256)) PasswordIterations = 256;

            if (PlainTextBytes == null)
                return null;

            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);
            byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);

            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);

            byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);

            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;

            byte[] CipherTextBytes = null;

            using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, InitialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                    {
                        CryptoStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                        CryptoStream.FlushFinalBlock();
                        CipherTextBytes = MemStream.ToArray();
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }

            SymmetricKey.Clear();

            return CipherTextBytes;

        }

        /// <summary>
        /// Decrypts a string
        /// </summary>
        /// <param name="CipherTextBytes">Bytes to be decrypted</param>
        /// <param name="Password">Password to decrypt with</param>
        /// <param name="Salt">Salt to decrypt with</param>
        /// <param name="HashAlgorithm">Can be either SHA1 or MD5</param>
        /// <param name="PasswordIterations">Number of iterations to do</param>
        /// <param name="InitialVector">Needs to be 16 ASCII characters long</param>
        /// <param name="KeySize">Can be 128, 192, or 256</param>
        /// <returns>A decrypted bytes</returns>
        public static byte[] Decrypt(
            byte[] CipherTextBytes,
            string Password,
            string Salt,
            string HashAlgorithm,
            int PasswordIterations,
            string InitialVector,
            int KeySize)
        {
            if ((Salt == null) || (Salt == "")) Salt = "Nextcom123";
            if ((HashAlgorithm == null) || (HashAlgorithm == "")) HashAlgorithm = "SHA1";
            if (PasswordIterations == 0) PasswordIterations = 2;
            if ((InitialVector == null) || (InitialVector == "") || (InitialVector.Length != 16)) InitialVector = "ANGh9M&op-*UL$W%";
            if ((KeySize != 128) && (KeySize != 192) && (KeySize != 256)) PasswordIterations = 256;

            if (CipherTextBytes == null)
                return null;

            byte[] InitialVectorBytes = Encoding.ASCII.GetBytes(InitialVector);

            byte[] SaltValueBytes = Encoding.ASCII.GetBytes(Salt);

            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Password, SaltValueBytes, HashAlgorithm, PasswordIterations);
            byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;

            byte[] PlainTextBytes = new byte[CipherTextBytes.Length];
            int ByteCount = 0;

            using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, InitialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream(CipherTextBytes))
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                    {
                        ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            SymmetricKey.Clear();
            return PlainTextBytes;
        }

        /// <summary>
        /// Compresses the string using G-Zip algorithm.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Compressed bytes array</returns>
        public static byte[] GZip_CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return gZipBuffer;
        }

        /// <summary>
        /// Decompresses the string using Gzip algorithm..
        /// </summary>
        /// <param name="gZipBuffer">The compressed bytes.</param>
        /// <returns></returns>
        public static string GZip_DeCompressString(byte[] gZipBuffer)
        {
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        /// <summary>
        /// Compresses the string using Deflate algorithm.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Compressed bytes array</returns>
        public static byte[] Deflate_CompressString(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress, true))
            {
                deflateStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var defalteBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, defalteBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, defalteBuffer, 0, 4);
            return defalteBuffer;
        }

        /// <summary>
        /// Decompresses the string using Deflate algorithm.
        /// </summary>
        /// <param name="gZipBuffer">The compressed bytes.</param>
        /// <returns></returns>
        public static string Deflate_DeCompressString(byte[] deflateBuffer)
        {
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(deflateBuffer, 0);
                memoryStream.Write(deflateBuffer, 4, deflateBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress))
                {
                    deflateStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        /// <summary>
        /// Formal string encryption for Gabiz Project
        /// </summary>
        /// <param name="plainText">Plain text</param>
        /// <returns>Cipher text in bytes array</returns>
        public static byte[] Encrypt(string plainText)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            return Crypto.Encrypt(unicode.GetBytes(plainText), "c#a1o*nt%d>-@d]v4&9d", "nextcom123", "SHA1", 2, "ANGh9M&op-*UL$W%", 256);
        }

        /// <summary>
        /// Formal string decryption for Gabiz Project
        /// </summary>
        /// <param name="cipherText">Cipher text in bytes array</param>
        /// <returns>Plain text</returns>
        public static string Decrypt(byte[] cipherText)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            return unicode.GetString(Crypto.Decrypt(cipherText, "c#a1o*nt%d>-@d]v4&9d", "nextcom123", "SHA1", 2, "ANGh9M&op-*UL$W%", 256)).TrimEnd('\0');
        }
    }
}
