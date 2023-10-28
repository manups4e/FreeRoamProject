using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FreeRoamProject.Shared.Core
{
    internal static class Encryption
    {
        public static string Decrypt(string strText, string sDecrKey)
        {
            byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
            byte[] array = new byte[strText.Length + 1];
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                array = Convert.FromBase64String(strText);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                Encoding uTF = Encoding.UTF8;
                return uTF.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public static string Encrypt(string strText, string strEncrKey)
        {
            byte[] rgbIV = new byte[8] { 18, 52, 86, 120, 144, 171, 205, 239 };
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                byte[] bytes2 = Encoding.UTF8.GetBytes(strText);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
                cryptoStream.Write(bytes2, 0, bytes2.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
