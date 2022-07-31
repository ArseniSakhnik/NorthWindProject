using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NorthWind.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    About = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CarModels = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServiceViews",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainImageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceViews", x => x.ServiceId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "About", "CarModels", "Description", "Path", "Title" },
                values: new object[,]
                {
                    { 1, "ООО \"Северный Ветер\" предлагает услуги работы КДМ с оператором.", "[{\"Indicator\":\"Модель шасси\",\"Parameter\":\"КАМАЗ-65115\"},{\"Indicator\":\"Масса машины полная, кг\",\"Parameter\":\"22400\"},{\"Indicator\":\"Ширина рабочей зоны, м (при мойке)\",\"Parameter\":\"8,5\"},{\"Indicator\":\"Ширина рабочей зоны, м (при мойке)\",\"Parameter\":\"8,5\"},{\"Indicator\":\"Ширина рабочей зоны, м (при поливке)\",\"Parameter\":\"20,0\"},{\"Indicator\":\"Ширина рабочей зоны, м (плуга)\",\"Parameter\":\"2,5\"},{\"Indicator\":\"Ширина рабочей зоны, м (щетки)\",\"Parameter\":\"2,3\"},{\"Indicator\":\"Рабочее давление воды, МПа\",\"Parameter\":\"до 2\"},{\"Indicator\":\"Диаметр очищаемых трубопроводов, мм\",\"Parameter\":\"50 – 300\"},{\"Indicator\":\"Тип топлива\",\"Parameter\":\"дизель\"},{\"Indicator\":\"Вместимость цистерны, м3\",\"Parameter\":\"11,0\"},{\"Indicator\":\"Длина, мм\",\"Parameter\":\"8000-12100\"},{\"Indicator\":\"Ширина, мм\",\"Parameter\":\"2950-3440\"},{\"Indicator\":\"Высота, мм\",\"Parameter\":\"3200\"}]", "Основная задача работы комбинированной дорожной машины заключается в удалении загрязнений, скапливающихся на поверхности проезжей части, стояночных площадей, территорий предприятий с асфальтовым и бетонным покрытием.\nТак же комбинированные дорожные машины используются для полива и увлажнения территорий и зеленых насаждений, что приводит к снижению запыленности воздуха, повышению влажности и созданию более комфортные условия для людей и окружающей среды.\nВ зимний период машина используется для  очистки территорий и дорожного полотна от свежевыпавшего снега.\n", "polivomoechnayaMashina.jpg", "КОМБИНИРОВАННЫЕ ДОРОЖНЫЕ МАШИНЫ" },
                    { 2, "ООО \"Северный Ветер\" предлагает услуги по вывозу КГО,ТСО.\nДля осуществления сбора, транспортирования и размещения на специализированном объекте твердых строительных и крупногабаритных  отходов, используется техника различного назначения.", "[{\"Indicator\":\"Базовое шасси\",\"Parameter\":\"МАЗ-5337\"},{\"Indicator\":\"Мощность двигателя\",\"Parameter\":\"240\"},{\"Indicator\":\"Вмесимость кузова полезная, м3\",\"Parameter\":\"8\"},{\"Indicator\":\"Масса загружаемых отходов, кг\",\"Parameter\":\"4000\"},{\"Indicator\":\"Полная масса, кг\",\"Parameter\":\"11000\"},{\"Indicator\":\"Масса спецоборудования, кг\\t\",\"Parameter\":\"1800\"},{\"Indicator\":\"Длина, мм\",\"Parameter\":\"6310\"},{\"Indicator\":\"Ширина, мм\",\"Parameter\":\"2500\"},{\"Indicator\":\"Высота, мм\",\"Parameter\":\"2970\"}]", "Отлично справляются с задачей по вывозу строительного и крупногабаритного мусора. Бункеровоз оборудован портальным механизмом для размещения на территории Заказчика, погрузки и перевозки бункера-накопителя объемом 8,0 куб. метров", "TwoBunkerTrucks.jpg", "БУНКЕРОВОЗЫ" },
                    { 3, "Для вывоза твёрдых строительных и крупногабаритных отходов ООО \"Северный Ветер\" предлагает мультилифт.", "[{\"Indicator\":\"Базовое шасси\",\"Parameter\":\"Мерседес-Бенц 1625\"},{\"Indicator\":\"Мощность двигателя\",\"Parameter\":\"250\"},{\"Indicator\":\"Вмесимость кузова полезная, м3\",\"Parameter\":\"27\"},{\"Indicator\":\"Масса загружаемых отходов, кг\",\"Parameter\":\"12000\"},{\"Indicator\":\"Полная масса, кг\",\"Parameter\":\"24000\"},{\"Indicator\":\"Масса спецоборудования, кг\",\"Parameter\":\"12000\"},{\"Indicator\":\"Длина, мм\",\"Parameter\":\"8000\"},{\"Indicator\":\"Ширина, мм\",\"Parameter\":\"2500\"},{\"Indicator\":\"Высота, мм\",\"Parameter\":\"3100\"}]", "Если вы занимаетесь строительством или ремонтом и скопилось очень много строительного и крупногабаритного мусора, то мы можем предложить МУЛЬТИЛЬФТ на базовом шасси Мерседес-Бенц 1625. Его бункер вмещает в себя объем 27 м. куб.", "multilift.jpg", "МУЛЬТИЛИФТ" },
                    { 4, "ООО \"Северный Ветер\" предлагает сотрудничество в сфере оказания услуг вакуумными машинами при проведении работ по откачке и вывозу всех видов канализационных стоков.машинами при проведении работ по откачке и вывозу всех видов канализационных стоков.", "[{\"Indicator\":\"Базовое шасси\",\"Parameter\":\"МАЗ-КО 523\"},{\"Indicator\":\"Мощность двигателя\",\"Parameter\":\"227\"},{\"Indicator\":\"Вмесимость цистерны, м3\",\"Parameter\":\"10\"},{\"Indicator\":\"Полная масса, кг\",\"Parameter\":\"18000\"},{\"Indicator\":\"Масса спецоборудования, кг\",\"Parameter\":\"10000\"},{\"Indicator\":\"Длина, мм\",\"Parameter\":\"6310\"},{\"Indicator\":\"Ширина, мм\",\"Parameter\":\"2500\"},{\"Indicator\":\"Высота, мм\",\"Parameter\":\"2970\"},{\"Indicator\":\"Стоимость услуги, р.\",\"Parameter\":\"от 2500\"}]", " Ассенизация – часто востребованная услуга в районах с частными застройками по очистке нечистот. Технология подразумевает работы по удалению жидких бытовых отходов (ЖБО).\nОбъем цистерн ассенизационных машин - 10 м. куб. и 11 м. куб.\nСтоимость откачки и вывоза зависит от вида выполняемых работ, удаленности объекта заказчика от очистных сооружений, объема и характера ЖБО.\nПеред тем, как заказать услугу ассенизатора, необходимо проконсультироваться со специалистом нашей компаннии.", "pumpingOutSepticTanks.jpg", "АССЕНИЗАТОР" }
                });

            migrationBuilder.InsertData(
                table: "ServiceViews",
                columns: new[] { "ServiceId", "MainImageName", "Title" },
                values: new object[,]
                {
                    { 1, "Assenizator.png", "ОТКАЧКА ЖИДКИХ БЫТОВЫХ ОТХОДОВ" },
                    { 2, "KGO.png", "ВЫВОЗ СТРОИТЕЛЬНОГО И КРУПНОГАБАРИТНОГО МУСОРА" },
                    { 3, "PolivIOchistkaTerrityriy.png", "ПОЛИВ И ОЧИСТКА ТЕРРИТОРИЙ" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "ServiceViews");
        }
    }
}
