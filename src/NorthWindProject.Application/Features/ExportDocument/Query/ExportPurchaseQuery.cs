using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.API.Models;
using NorthWindProject.Application.Common.Access;
using Spire.Doc;
using Spire.Doc.Documents;

namespace NorthWindProject.Application.Features.ExportDocument.Query
{
    public class ExportPurchaseQuery : IRequest<FileModel>
    {
        public int PurchaseId { get; set; }
        public string ServiceName { get; set; }
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

            var documentContent = await _context.Purchases
                .Where(purchase => purchase.Id == request.PurchaseId)
                .SelectMany(purchase => purchase.Service.DocumentServices)
                .Select(document => document.Content)
                .SingleOrDefaultAsync(cancellationToken);

            var purchaseFields = await _context.FieldPurchases
                .Where(field => field.PurchaseId == request.PurchaseId)
                .Include(field => field.FieldService)
                .ToListAsync(cancellationToken);

            var purchaseUserName = await _context.Users
                .Where(user => user.Purchases.Any(purchase => purchase.Id == request.PurchaseId))
                .Select(user => $"{user.UserName} {user.Surname} {user.MiddleName}")
                .SingleOrDefaultAsync(cancellationToken);

            await using var stream = new MemoryStream(documentContent);
            var document = new Document(stream);
            var booksMarkNavigator = new BookmarksNavigator(document);


            purchaseFields.ForAll(pField =>
            {
                booksMarkNavigator.MoveToBookmark(pField.FieldService.BookMarkName);
                booksMarkNavigator.InsertText(pField.Value, true);
            });

            document.SaveToStream(stream, FileFormat.Doc);

            return new FileModel
            {
                Name = $"{request.ServiceName} {purchaseUserName}",
                Content = stream.ToArray()
            };
        }
    }
}