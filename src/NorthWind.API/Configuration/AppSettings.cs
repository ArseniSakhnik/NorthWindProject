namespace NorthWind.API.Configuration
{
    public class AppSettings
    {
        public string Connection { get; set; }

        public string MySqlMajorVersion { get; set; }
        public string MySqlMinorVersion { get; set; }
        public string MySqlBuild { get; set; }
    }
}