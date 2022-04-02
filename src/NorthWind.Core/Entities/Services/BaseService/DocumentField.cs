namespace NorthWind.Core.Entities.Services.BaseService
{
    public class DocumentField
    {
        public DocumentField(string propertyName, string bookMarkName)
        {
            PropertyName = propertyName
                .ToLower()
                .Trim();
            BookMarkName = bookMarkName
                .Trim();
        }

        public string PropertyName { get; set; }
        public string BookMarkName { get; set; }
    }
}