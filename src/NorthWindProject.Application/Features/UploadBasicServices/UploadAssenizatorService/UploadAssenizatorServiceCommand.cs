using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;
using Microsoft.AspNetCore.Http;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Service;
using NorthWindProject.Application.Enums;

namespace NorthWindProject.Application.Features.UploadBasicServices.UploadAssenizatorService
{
    public class UploadAssenizatorServiceCommand : IRequest
    {
        public IFormFile File { get; set; }
    }

    public class UploadAssenizatorServiceCommandHandler : IRequestHandler<UploadAssenizatorServiceCommand>
    {
        private readonly AppDbContext _context;

        public UploadAssenizatorServiceCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UploadAssenizatorServiceCommand request, CancellationToken cancellationToken)
        {
            // var service = new Entities.Service.Service
            // {
            //     Id = 1,
            //     Name = "Вывоз житких бытовых отходов",
            //     Description = "",
            // };
            //
            // await _context.Services.AddAsync(service, cancellationToken);
            //
            // await using var stream = new MemoryStream();
            // await request.File.OpenReadStream().CopyToAsync(stream, cancellationToken);
            //
            // var documentService = new DocumentService
            // {
            //     Id = 1,
            //     Name = $"Договор № на вывоз жидких бытовых отходов",
            //     ServiceId = service.Id,
            //     Content = stream.ToArray(),
            // };
            //
            // await _context.DocumentServices.AddAsync(documentService, cancellationToken);
            //
            // service.DocumentServices = new List<DocumentService>(new[] {documentService});
            //
            // var fields = new List<FieldService>
            // {
            //     new()
            //     {
            //         DocumentServiceId = documentService.Id,
            //         FieldTypeId = FieldServiceTypeEnum.Day,
            //         BookMarkName = "День",
            //     },
            //     new()
            //     {
            //         DocumentServiceId = documentService.Id,
            //         FieldTypeId = FieldServiceTypeEnum.Month,
            //         BookMarkName = "Месяц"
            //     },
            //     new()
            //     {
            //         DocumentServiceId = documentService.Id,
            //         FieldTypeId = FieldServiceTypeEnum.Year,
            //         BookMarkName = "Год"
            //     },
            //     new()
            //     {
            //         DocumentServiceId = documentService.Id,
            //         FieldTypeId = FieldServiceTypeEnum.Text,
            //         BookMarkName = "АдресТерритории"
            //     },
            // };
            //
            // await _context.FieldServices.AddRangeAsync(fields, cancellationToken);
            //
            // documentService.FieldServices = fields;
            //
            // await _context.SaveChangesAsync(cancellationToken);

            var service = new Entities.Service.Service
            {
                Id = 1,
                Name = "Вывоз житких бытовых отходов",
                Description = "",
            };

            await _context.Services.AddAsync(service, cancellationToken);
            
            await using var stream = new MemoryStream();
            await request.File.OpenReadStream().CopyToAsync(stream, cancellationToken);

            var documentService = new DocumentService
            {
                Id = 1,
                ServiceId = service.Id,
                Content = stream.ToArray(),
                Name = $"Договор № на вывоз жидких бытовых отходов",
            };
            
            var fields = new List<FieldService>
            {
                new()
                {
                    
                    DocumentServiceId = documentService.Id,
                    FieldTypeId = FieldServiceTypeEnum.Day,
                    BookMarkName = "День",
                },
                new()
                {
                    DocumentServiceId = documentService.Id,
                    FieldTypeId = FieldServiceTypeEnum.Month,
                    BookMarkName = "Месяц"
                },
                new()
                {
                    DocumentServiceId = documentService.Id,
                    FieldTypeId = FieldServiceTypeEnum.Year,
                    BookMarkName = "Год"
                },
                new()
                {
                    DocumentServiceId = documentService.Id,
                    FieldTypeId = FieldServiceTypeEnum.Text,
                    BookMarkName = "АдресТерритории"
                },
            };
            
            
            return Unit.Value;
        }   
    }
}