namespace NorthWind.Core.Interfaces
{
    public interface IEncryptObject
    {
        void DecryptObject(IEncryptionService encryptionService);
        void EncryptObject(IEncryptionService encryptionService);
    }
}