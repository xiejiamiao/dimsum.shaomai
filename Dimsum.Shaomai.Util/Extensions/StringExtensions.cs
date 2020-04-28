using System;
using System.Collections.Generic;
using System.Text;
using NETCore.Encrypt;

namespace Dimsum.Shaomai.Util.Extensions
{
    public static class StringExtensions
    {
        public static string ToMd5(this string str)
        {
            return EncryptProvider.Md5(str);
        }
    }
}
