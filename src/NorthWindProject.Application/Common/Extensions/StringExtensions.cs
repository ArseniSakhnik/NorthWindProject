using System;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace NorthWindProject.Application.Common.Extensions
{
    public static class StringExtensions
    {
        public static string GetRandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            var res = new StringBuilder();
            var rnd = new Random();

            while (0 < length--) res.Append(valid[rnd.Next(valid.Length)]);

            return res.ToString();
        }

        public static string GetCallbackUrl(HttpRequest request)
        {
            return $"{request.Scheme}://{request.Host.Value}";
        }

        public static bool IsEmpty(this string str)
        {
            return str is not null && string.IsNullOrEmpty(str.Trim());
        }
    }
}