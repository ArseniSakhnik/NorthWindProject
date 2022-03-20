using System;
using System.Linq.Expressions;

namespace NorthWindProject.Application.Interfaces
{
    public interface IEncryptionService
    {
        public string Encrypt(string str);

        public string Decipher(string str);
    }
}