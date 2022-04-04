﻿using System.ComponentModel.DataAnnotations.Schema;
using NorthWind.Core.Attributes;
using NorthWind.Core.Entities.Purchases.BasePurchase;
using NorthWind.Core.Interfaces;

namespace NorthWind.Core.Entities.Purchases.VacuumTruckPurchaseYur
{
    [Table("VacuumTruckYurPurchase")]
    public class VacuumTruckYurPurchase : Purchase, IEncryptObject
    {
        [DocumentProp("заказчиккороткоеимя")] public string ClientShortName { get; set; }
        [DocumentProp("ипкороткоеимя")] public string PersonalNameEntrepreneur { get; set; }
        [DocumentProp("действуетнаосновании")] public string ActsOnBasis { get; set; }
        [DocumentProp("адрестерритории")] public string TerritoryAddress { get; set; }
        [DocumentProp("ценачисло")] public string Price { get; set; }
        [DocumentProp("ценастрока")] public string PriceString { get; set; }
        [DocumentProp("огрн")] public string OGRN { get; set; }
        [DocumentProp("инн")] public string INN { get; set; }
        [DocumentProp("кпп")] public string KPP { get; set; }
        [DocumentProp("юрадрес")] public string LegalAddress { get; set; }
        [DocumentProp("номертелефона")] public string PhoneNumber { get; set; }
        [DocumentProp("email")] public string Email { get; set; }
        public void DecryptObject(IEncryptionService encryptionService)
        {
            throw new System.NotImplementedException();
        }

        public void EncryptObject(IEncryptionService encryptionService)
        {
            throw new System.NotImplementedException();
        }
    }
}