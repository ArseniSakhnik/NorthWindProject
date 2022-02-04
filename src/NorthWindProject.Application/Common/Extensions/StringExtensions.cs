using System;
using System.Text;

namespace NorthWindProject.Application.Common.Extensions
{
    public static class StringExtensions
    {
        public static string GetRandomString(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            
            var res = new StringBuilder();
            var rnd = new Random();
            
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}