namespace NorthWind.Core.Interfaces
{
    public interface IEncryptionService
    {
        public string Encrypt(string str);

        public string Decipher(string str);
    }
}