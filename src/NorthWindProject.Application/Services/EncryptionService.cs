using Elskom.Generic.Libs;
using Microsoft.Extensions.Options;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.ConfigurationModels;

namespace NorthWindProject.Application.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly BlowFish _blowFish;

        public EncryptionService(IOptions<SecretSettings> secretOptions)
        {
            _blowFish = new BlowFish(secretOptions.Value.SecretKey);
        }

        public string Encrypt(string str)
        {
            // return _blowFish.EncryptCBC(str);
            return str;
        }

        public string Decipher(string str)
        {
            // return _blowFish.DecryptCBC(str);
            return str;
        }
    }
}