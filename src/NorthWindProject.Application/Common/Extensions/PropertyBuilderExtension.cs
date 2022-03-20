using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NorthWindProject.Application.Common.Extensions
{
    public static class PropertyBuilderExtension
    {
        public static PropertyBuilder<string> HasEncryptDecrypt(
            this PropertyBuilder<string> extension,
            Func<string, string> encrypt,
            Func<string, string> decrypt)
        {
            return extension.HasConversion
            (
                v => encrypt(v),
                v => decrypt(v)
            );
        }
    }
}