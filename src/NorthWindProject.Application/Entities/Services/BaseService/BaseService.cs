using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWindProject.Application.Entities.Services.BaseService
{
    public abstract class BaseService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DocumentService.DocumentService> DocumentServices { get; set; } = new();
    }
}