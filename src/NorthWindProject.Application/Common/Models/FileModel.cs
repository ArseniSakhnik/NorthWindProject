namespace NorthWind.API.Models
{
    public class FileModel
    {
        public string Name { get; set; } = "Файл";
        public byte[] Content { get; set; }
    }
}