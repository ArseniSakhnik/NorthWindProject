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
using NorthWindProject.Application.Enums.AssenizatorServiceEnums;

namespace NorthWindProject.Application.Features.UploadBasicServices.UploadAssenizatorService
{
    public class UploadAssenizatorServiceCommand : IRequest
    {
        public IFormFile File { get; set; }
    }

    public class UploadAssenizatorServiceCommandHandler : IRequestHandler<UploadAssenizatorServiceCommand>
    {
        private readonly AppDbContext _context;
        private const int assenizatorServicesId = (int) ServicesEnum.Ассенизатор;

        public UploadAssenizatorServiceCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UploadAssenizatorServiceCommand request, CancellationToken cancellationToken)
        {
            await AddServiceAsync(cancellationToken);
            await AddDocumentServiceIndividualAsync(request.File, cancellationToken);
            await AddDocumentServiceIndividualFieldsAsync(cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task AddServiceAsync(CancellationToken cancellationToken)
        {
            var service = new Service
            {
                Id = assenizatorServicesId,
                Name = "Вывоз строительного и крупногабаритного мусора",
                Description = "",
            };

            await _context.Services.AddAsync(service, cancellationToken);
        }


        private async Task AddDocumentServiceIndividualAsync(IFormFile file, CancellationToken cancellationToken)
        {
            await using var stream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(stream, cancellationToken);

            var documentService = new DocumentService
            {
                Id = 1,
                Content = stream.ToArray(),
                Name = "Договор на вывоз жидких бытовых отходов",
                ServiceId = assenizatorServicesId
            };

            await _context.DocumentServices.AddAsync(documentService, cancellationToken);
        }

        private async Task AddDocumentServiceIndividualFieldsAsync(CancellationToken cancellationToken)
        {
            var fields = new List<FieldService>
            {
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.Дата,
                    BookMarkName = "Дата",
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.Месяц,
                    BookMarkName = "Месяц",
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.День,
                    BookMarkName = "Год"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ФИО,
                    BookMarkName = "ФизическоеЛицо"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ПаспортСерия,
                    BookMarkName = "ПаспортСерия"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ПаспортНомер,
                    BookMarkName = "ПаспортНомер"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ПаспортВыдан,
                    BookMarkName = "ПаспортВыдан"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ПаспортДатаВыдачи,
                    BookMarkName = "ПаспортДатаВыдачи"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.АдресТерритории,
                    BookMarkName = "АдресТерритории"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ПаспортКП,
                    BookMarkName = "КП"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.АдресРегистрации,
                    BookMarkName = "АдресРегистрации"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ЦенаЧисло,
                    BookMarkName = "ЦенаЧисло"
                },
                new()
                {
                    FieldTypeId = AssenizatorServiceFieldsTypeEnum.ЦенаСтрока,
                    BookMarkName = "ЦенаСтрока"
                }
            };

            fields.ForAll(field => field.DocumentServiceId = assenizatorServicesId);

            await _context.FieldServices.AddRangeAsync(fields, cancellationToken);
        }
    }
}