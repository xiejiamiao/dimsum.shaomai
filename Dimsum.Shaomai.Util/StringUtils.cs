using System;
using System.Collections.Generic;
using System.Text;
using NETCore.Encrypt;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

// ReSharper disable StringLiteralTypo

namespace Dimsum.Shaomai.Util
{
    public class StringUtils
    {
        
        public static string SourceWithCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890`~!@#$%^&*()_+-=[]{};':,./<>?";

        public static string SourceWithoutCharacter = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        /// <summary>
        /// 随机字符串(种子带符号)
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomStringWithCharacter(int length)
        {
            var result =new StringBuilder();
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                result.Append(SourceWithCharacter[random.Next(0, SourceWithCharacter.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// 随机字符串(种子无符号)
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string RandomStringWithoutCharacter(int length)
        {
            var result = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < length; i++)
            {
                result.Append(SourceWithoutCharacter[random.Next(0, SourceWithoutCharacter.Length)]);
            }
            return result.ToString();
        }

        public static (string PublicKey,string privateKey) RSAInfoByPKCS8()
        {
            var pkcs8KeyTuple = EncryptProvider.RSAToPem(true);
            return (pkcs8KeyTuple.publicPem, pkcs8KeyTuple.privatePem);
        }

        public static string EncryptRSA(string publicKey, string srcString)
        {
            return  EncryptProvider.RSAEncryptWithPem(publicKey, srcString);
        }

        public static string DecryptRSA(string privateKey, string srcString)
        {
            return EncryptProvider.RSADecryptWithPem(privateKey, srcString);
        }
    }
}
