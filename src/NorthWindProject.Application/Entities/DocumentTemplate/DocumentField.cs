using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Entities.DocumentTemplate
{
    public class DocumentField
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }

        public DocumentTypeField DocumentTypeId { get; set; }
        public string Benchmark { get; set; }
    }
}