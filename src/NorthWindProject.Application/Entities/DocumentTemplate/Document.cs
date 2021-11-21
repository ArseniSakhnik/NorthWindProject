using System.Collections.Generic;

namespace NorthWindProject.Application.Entities.DocumentTemplate
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public List<DocumentField> Fields { get; set; }
    }
}