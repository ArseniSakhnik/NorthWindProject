using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.Service
{
    public class ServiceProp
    {
        public int ServicePropId { get; set; }

        public Service Service { get; set; }
        public int ServiceId { get; set; }

        /// <summary>
        ///     Тип поля сервиса
        /// </summary>
        public ServicePropTypeEnum ServicePropTypeId { get; set; }

        /// <summary>
        ///     Допустимые значения поля сервиса
        /// </summary>
        public List<PermissibleValue> PermissibleValues { get; set; }

        /// <summary>
        ///     Название поля
        /// </summary>
        public string Name { get; set; }
    }
}