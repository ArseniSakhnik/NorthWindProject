using NorthWind.Core.Attributes;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Contracts.BaseContract
{
    public abstract class YurContract : Contract, IEncryptObject
    {
        [DocumentProp("инн")] public string INN { get; set; }

        [DocumentProp("кпп")] public string KPP { get; set; }

        [DocumentProp("огрн")] public string OGRN { get; set; }

        [DocumentProp("окпо")] public string OKPO { get; set; }

        [DocumentProp("юрадрес")] public string YurAddress { get; set; }

        [DocumentProp("заказчиккороткоеимя")] public string CustomerShortName { get; set; }

        [DocumentProp("ипкороткоеимя")] public string IEShortName { get; set; }

        [DocumentProp("действуетнаосновании")] public string OperatesOnBasis { get; set; }


        public void DecryptObject(IEncryptionService encryptionService)
        {
            INN = encryptionService.Decipher(INN);
            KPP = encryptionService.Decipher(KPP);
            OGRN = encryptionService.Decipher(OGRN);
            OKPO = encryptionService.Decipher(OKPO);
            YurAddress = encryptionService.Decipher(YurAddress);
            CustomerShortName = encryptionService.Decipher(CustomerShortName);
            IEShortName = encryptionService.Decipher(IEShortName);
            OperatesOnBasis = encryptionService.Decipher(OperatesOnBasis);
        }

        public void EncryptObject(IEncryptionService encryptionService)
        {
            INN = encryptionService.Encrypt(INN);
            KPP = encryptionService.Encrypt(KPP);
            OGRN = encryptionService.Encrypt(OGRN);
            OKPO = encryptionService.Encrypt(OKPO);
            YurAddress = encryptionService.Encrypt(YurAddress);
            CustomerShortName = encryptionService.Encrypt(CustomerShortName);
            IEShortName = encryptionService.Encrypt(IEShortName);
            OperatesOnBasis = encryptionService.Encrypt(OperatesOnBasis);
        }
    }
}