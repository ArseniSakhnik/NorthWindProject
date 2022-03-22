namespace NorthWindProject.Application.Entities.Services.BaseService
{
    public class DocumentField
    {
        public string PropertyName { get; set; }
        public string BookMarkName { get; set; }

        public DocumentField(string propertyName, string bookMarkName)
        {
            PropertyName = propertyName.ToLower();
            BookMarkName = bookMarkName;
        }
    }
}