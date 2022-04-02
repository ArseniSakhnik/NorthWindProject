using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.Services.Command.LoadServiceDocumentTemplate
{
    public class LoadServiceDocumentTemplateCommand : IRequest
    {
        public int ServiceId { get; set; }
        public IFormFile File { get; set; }
    }

    public class LoadServiceDocumentTemplateCommandHandler : IRequestHandler<LoadServiceDocumentTemplateCommand>
    {
        private readonly AppDbContext _context;

        public LoadServiceDocumentTemplateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(LoadServiceDocumentTemplateCommand request, CancellationToken cancellationToken)
        {
            var service = await _context.Services
                .Include(service => service.DocumentServices)
                .SingleOrDefaultAsync(service => (int) service.Id == request.ServiceId, cancellationToken);

            await using var stream = new MemoryStream();
            await request.File.OpenReadStream().CopyToAsync(stream, cancellationToken);

            //TODO пока что по умолчанию один файл
            var documentService = service.DocumentServices.First();
            documentService.Content = stream.ToArray();

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}