using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Common.Extensions;
using NorthWindProject.Application.Common.Models;
using Spire.Doc;
using Spire.Doc.Documents;

namespace NorthWindProject.Application.Features.ExportDocument.Query.ExportContract
{
    public class ExportContractQuery : IRequest<FileModel>
    {
        public int ContractId { get; set; }
    }

    public class ExportContractQueryHandler : IRequestHandler<ExportContractQuery, FileModel>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptionService _encryptionService;

        public ExportContractQueryHandler(AppDbContext context, IEncryptionService encryptionService)
        {
            _context = context;
            _encryptionService = encryptionService;
        }

        public async Task<FileModel> Handle(ExportContractQuery request, CancellationToken cancellationToken)
        {
            var contract = await _context.Contracts
                .Include(contract => contract.Service)
                .ThenInclude(service => service.DocumentServices)
                .SingleOrDefaultAsync(contract => contract.Id == request.ContractId, cancellationToken);

            if (contract is IEncryptObject encryptObject) encryptObject.DecryptObject(_encryptionService);

            //todo возможно появление дополнительных документов
            var documentData = contract.Service.DocumentServices.First();
            var documentContent = documentData.Content;

            await using var stream = new MemoryStream(documentContent);
            var document = new Document(stream);
            var booksMarkNavigator = new BookmarksNavigator(document);
            var bookMarks = booksMarkNavigator.Document.Bookmarks;
            var namesAndValues = contract.GetNameAndValuesDictionary;

            var index = 0;
            foreach (Bookmark mark in bookMarks)
            {
                index++;

                try
                {
                    var documentField = documentData.DocumentFields
                        .SingleOrDefault(field => mark.Name.Contains(field.BookMarkName));

                    if (documentField is null) continue;

                    booksMarkNavigator.MoveToBookmark(mark.Name);

                    if (!namesAndValues[documentField.PropertyName].IsEmpty())
                        // booksMarkNavigator.InsertText(namesAndValues[documentField.PropertyName]);
                        booksMarkNavigator.ReplaceBookmarkContent(namesAndValues[documentField.PropertyName], true);
                }
                catch
                {
                }
            }

            document.SaveToStream(stream, FileFormat.Doc);

            return new FileModel
            {
                Content = stream.ToArray()
            };
        }
    }
}