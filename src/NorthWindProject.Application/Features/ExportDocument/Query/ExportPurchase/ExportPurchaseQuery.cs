using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Models;
using Spire.Doc;
using Spire.Doc.Documents;

namespace NorthWindProject.Application.Features.ExportDocument.Query.ExportPurchase
{
    public class ExportPurchaseQuery : IRequest<FileModel>
    {
        public int PurchaseId { get; set; }
    }

    public class ExportPurchaseQueryHandler : IRequestHandler<ExportPurchaseQuery, FileModel>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public ExportPurchaseQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<FileModel> Handle(ExportPurchaseQuery request, CancellationToken cancellationToken)
        {
            var purchase = await _context.Purchases
                .Include(purchase => purchase.Service)
                .ThenInclude(service => service.DocumentServices)
                .SingleOrDefaultAsync(purchase => purchase.Id == request.PurchaseId, cancellationToken);

            if (purchase is IEncryptObject encryptObject) encryptObject.DecryptObject(_encryptionService);

            //todo возможно появление дополнительных документов
            var documentData = purchase.Service.DocumentServices.First();
            var documentContent = documentData.Content;

            await using var stream = new MemoryStream(documentContent);
            var document = new Document(stream);
            var booksMarkNavigator = new BookmarksNavigator(document);
            var bookMarks = booksMarkNavigator.Document.Bookmarks;
            var namesAndValues = purchase.GetNameAndValuesDictionary;

            foreach (Bookmark mark in bookMarks)
            {
                var documentField = documentData.DocumentFields
                    .SingleOrDefault(field => mark.Name.Contains(field.BookMarkName));

                if (documentField is null) continue;

                booksMarkNavigator.MoveToBookmark(mark.Name);
                booksMarkNavigator.InsertText(namesAndValues[documentField.PropertyName]);
            }

            document.SaveToStream(stream, FileFormat.Doc);

            return new FileModel
            {
                Content = stream.ToArray()
            };
        }
    }
}