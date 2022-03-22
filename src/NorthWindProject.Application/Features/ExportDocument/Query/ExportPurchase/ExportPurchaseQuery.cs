using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Purchases.BasePurchase;
using NorthWindProject.Application.Entities.Services.BaseService;
using Spire.Doc;
using Spire.Doc.Documents;

namespace NorthWindProject.Application.Features.ExportDocument.Query.ExportPurchase
{
    public class ExportPurchaseQuery : IRequest<FileModel>
    {
        public BasePurchase Purchase { get; set; }
    }
    
    public class ExportPurchaseQueryHandler : IRequestHandler<ExportPurchaseQuery, FileModel>
    {
        private readonly AppDbContext _context;

        public ExportPurchaseQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FileModel> Handle(ExportPurchaseQuery request, CancellationToken cancellationToken)
        {
            //todo возможно появление дополнительных документов
            var documentData = request.Purchase.Service.DocumentServices.First();
            var documentContent = documentData.Content;

            await using var stream = new MemoryStream(documentContent);
            var document = new Document(stream);
            var booksMarkNavigator = new BookmarksNavigator(document);
            var bookMarks = booksMarkNavigator.Document.Bookmarks;
            var namesAndValues = request.Purchase.GetNameAndValuesDictionary;
            
            foreach (Bookmark mark in bookMarks)
            {
                var documentField = documentData.DocumentFields
                    .SingleOrDefault(field => mark.Name.Contains(field.BookMarkName));

                if (documentField is null)
                {
                    continue;
                }
                
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