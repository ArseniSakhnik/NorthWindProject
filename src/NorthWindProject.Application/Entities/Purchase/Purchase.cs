using System.Collections.Generic;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Entities.Purchase
{
    public class Purchase
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int DocumentTemplateId { get; set; }
        public DocumentTemplate.Document Document { get; set; }

        public List<PurchaseField> Fields { get; set; }
    }
}