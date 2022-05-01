using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using NorthWind.Core.Entities.Car;

namespace NorthWindProject.Application.Common.Configuration.ConfigurationEntities
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(e => e.CarModels).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<CarInfoModel>>(v));

            builder.HasData(new List<Car>
            {
                #region КОМБИНИРОВАННЫЕ ДОРОЖНЫЕ МАШИНЫ

                new()
                {
                    Id = 1,
                    Title = "КОМБИНИРОВАННЫЕ ДОРОЖНЫЕ МАШИНЫ",
                    About = "ООО \"Северный Ветер\" предлагает услуги работы КДМ с оператором.",
                    Path = "polivomoechnayaMashina.jpg",
                    Description =
                        "Основная задача работы комбинированной дорожной машины заключается в удалении загрязнений, "
                        + "скапливающихся на поверхности проезжей части, стояночных площадей, территорий предприятий "
                        + "с асфальтовым и бетонным покрытием.\n"
                        + "Так же комбинированные дорожные машины используются для полива и увлажнения территорий и "
                        + "зеленых насаждений, что приводит к снижению запыленности воздуха, повышению влажности и "
                        + "созданию более комфортные условия для людей и окружающей среды.\n"
                        + "В зимний период машина используется для  очистки территорий и дорожного полотна от " +
                        "свежевыпавшего снега.\n",
                    CarModels = new List<CarInfoModel>
                    {
                        new()
                        {
                            Indicator = "Модель шасси",
                            Parameter = "КАМАЗ-65115"
                        },
                        new()
                        {
                            Indicator = "Масса машины полная, кг",
                            Parameter = "22400"
                        },
                        new()
                        {
                            Indicator = "Ширина рабочей зоны, м (при мойке)",
                            Parameter = "8,5"
                        },
                        new()
                        {
                            Indicator = "Ширина рабочей зоны, м (при мойке)",
                            Parameter = "8,5"
                        },
                        new()
                        {
                            Indicator = "Ширина рабочей зоны, м (при поливке)",
                            Parameter = "20,0"
                        },
                        new()
                        {
                            Indicator = "Ширина рабочей зоны, м (плуга)",
                            Parameter = "2,5"
                        },
                        new()
                        {
                            Indicator = "Ширина рабочей зоны, м (щетки)",
                            Parameter = "2,3"
                        },
                        new()
                        {
                            Indicator = "Рабочее давление воды, МПа",
                            Parameter = "до 2"
                        },
                        new()
                        {
                            Indicator = "Диаметр очищаемых трубопроводов, мм",
                            Parameter = "50 – 300"
                        },
                        new()
                        {
                            Indicator = "Тип топлива",
                            Parameter = "дизель"
                        },
                        new()
                        {
                            Indicator = "Вместимость цистерны, м3",
                            Parameter = "11,0"
                        },
                        new()
                        {
                            Indicator = "Длина, мм",
                            Parameter = "8000-12100"
                        },
                        new()
                        {
                            Indicator = "Ширина, мм",
                            Parameter = "2950-3440"
                        },
                        new()
                        {
                            Indicator = "Высота, мм",
                            Parameter = "3200"
                        }
                    }
                },

                #endregion

                #region БУНКЕРОВОЗЫ

                new()
                {
                    Id = 2,
                    Title = "БУНКЕРОВОЗЫ",
                    About = "ООО \"Северный Ветер\" предлагает услуги по вывозу КГО,ТСО.\n"
                            + "Для осуществления сбора, транспортирования и размещения на специализированном объекте твердых "
                            + "строительных и крупногабаритных  отходов, используется техника различного назначения.",
                    Description =
                        "Отлично справляются с задачей по вывозу строительного и крупногабаритного мусора. Бункеровоз "
                        + "оборудован портальным механизмом для размещения на территории Заказчика, погрузки и"
                        + " перевозки бункера-накопителя объемом 8,0 куб. метров",
                    Path = "TwoBunkerTrucks.jpg",
                    CarModels = new List<CarInfoModel>
                    {
                        new()
                        {
                            Indicator = "Базовое шасси",
                            Parameter = "МАЗ-5337"
                        },
                        new()
                        {
                            Indicator = "Мощность двигателя",
                            Parameter = "240"
                        },
                        new()
                        {
                            Indicator = "Вмесимость кузова полезная, м3",
                            Parameter = "8"
                        },
                        new()
                        {
                            Indicator = "Масса загружаемых отходов, кг",
                            Parameter = "4000"
                        },
                        new()
                        {
                            Indicator = "Полная масса, кг",
                            Parameter = "11000"
                        },
                        new()
                        {
                            Indicator = "Масса спецоборудования, кг	",
                            Parameter = "1800"
                        },
                        new()
                        {
                            Indicator = "Длина, мм",
                            Parameter = "6310"
                        },
                        new()
                        {
                            Indicator = "Ширина, мм",
                            Parameter = "2500"
                        },
                        new()
                        {
                            Indicator = "Высота, мм",
                            Parameter = "2970"
                        }
                    }
                },

                #endregion

                #region МУЛЬТИЛИФТ

                new()
                {
                    Id = 3,
                    Title = "МУЛЬТИЛИФТ",
                    About = "Для вывоза твёрдых строительных и крупногабаритных отходов ООО \"Северный Ветер\" "
                            + "предлагает мультилифт.",
                    Description = "Если вы занимаетесь строительством или ремонтом и скопилось очень много "
                                  + "строительного и крупногабаритного мусора, то мы можем предложить МУЛЬТИЛЬФТ"
                                  + " на базовом шасси Мерседес-Бенц 1625. Его бункер вмещает в себя объем 27 м. куб.",
                    Path = "multilift.jpg",
                    CarModels = new List<CarInfoModel>
                    {
                        new()
                        {
                            Indicator = "Базовое шасси",
                            Parameter = "Мерседес-Бенц 1625"
                        },
                        new()
                        {
                            Indicator = "Мощность двигателя",
                            Parameter = "250"
                        },
                        new()
                        {
                            Indicator = "Вмесимость кузова полезная, м3",
                            Parameter = "27"
                        },
                        new()
                        {
                            Indicator = "Масса загружаемых отходов, кг",
                            Parameter = "12000"
                        },
                        new()
                        {
                            Indicator = "Полная масса, кг",
                            Parameter = "24000"
                        },
                        new()
                        {
                            Indicator = "Масса спецоборудования, кг",
                            Parameter = "12000"
                        },
                        new()
                        {
                            Indicator = "Длина, мм",
                            Parameter = "8000"
                        },
                        new()
                        {
                            Indicator = "Ширина, мм",
                            Parameter = "2500"
                        },
                        new()
                        {
                            Indicator = "Высота, мм",
                            Parameter = "3100"
                        }
                    }
                },

                #endregion

                #region АССЕНИЗАТОР

                new()
                {
                    Id = 4,
                    Title = "АССЕНИЗАТОР",
                    About = "ООО \"Северный Ветер\" предлагает сотрудничество в сфере оказания услуг вакуумными "
                            + "машинами при проведении работ по откачке и вывозу всех видов канализационных стоков."
                            + "машинами при проведении работ по откачке и вывозу всех видов канализационных стоков.",
                    Description = " Ассенизация – часто востребованная услуга в районах с частными застройками по "
                                  + "очистке нечистот. Технология подразумевает работы по удалению жидких бытовых "
                                  + "отходов (ЖБО).\n"
                                  + "Объем цистерн ассенизационных машин - 10 м. куб. и 11 м. куб.\n"
                                  + "Стоимость откачки и вывоза зависит от вида выполняемых работ, удаленности объекта заказчика "
                                  + "от очистных сооружений, объема и характера ЖБО.\n"
                                  + "Перед тем, как заказать услугу ассенизатора, необходимо проконсультироваться со специалистом нашей компаннии.",
                    Path = "pumpingOutSepticTanks.jpg",
                    CarModels = new List<CarInfoModel>
                    {
                        new()
                        {
                            Indicator = "Базовое шасси",
                            Parameter = "МАЗ-КО 523"
                        },
                        new()
                        {
                            Indicator = "Мощность двигателя",
                            Parameter = "227"
                        },
                        new()
                        {
                            Indicator = "Вмесимость цистерны, м3",
                            Parameter = "10"
                        },
                        new()
                        {
                            Indicator = "Полная масса, кг",
                            Parameter = "18000"
                        },
                        new()
                        {
                            Indicator = "Масса спецоборудования, кг",
                            Parameter = "10000"
                        },
                        new()
                        {
                            Indicator = "Длина, мм",
                            Parameter = "6310"
                        },
                        new()
                        {
                            Indicator = "Ширина, мм",
                            Parameter = "2500"
                        },
                        new()
                        {
                            Indicator = "Высота, мм",
                            Parameter = "2970"
                        },
                        new()
                        {
                            Indicator = "Стоимость услуги, р.",
                            Parameter = "от 2500"
                        }
                    }
                }

                #endregion
            });
        }
    }
}