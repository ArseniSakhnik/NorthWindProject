namespace NorthWindProject.Application.Interfaces
{
    public interface IEncryptObject
    {
        void DecryptObject(IEncryptionService encryptionService);
        void EncryptObject(IEncryptionService encryptionService);
    }
}