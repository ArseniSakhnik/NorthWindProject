using System.Collections.Generic;

namespace NorthWindProject.Application.Common.Models
{
    public class EmailBodyModel
    {
        public string ToEmail { get; set; }
        public string Username { get; set; }
        public string Subject { get; set; }
        public string HtmlBody { get; set; }
        public List<FileModel> Files { get; set; } = new();
    }
}