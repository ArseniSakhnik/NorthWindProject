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
using NorthWindProject.Application.Enums.VacuumTruckServiceEnums;

namespace NorthWindProject.Application.Features.UploadBasicServices.UploadVacuumTruckService
{
    public class UploadVacuumTruckServiceCommand : IRequest
    {
        public IFormFile File { get; set; }
    }

    public class UploadVacuumTruckServiceCommandHandler : IRequestHandler<UploadVacuumTruckServiceCommand>
    {
        private readonly AppDbContext _context;
        private const int VacuumTruckServicesId = (int) ServicesEnum.Ассенизатор;

        public UploadVacuumTruckServiceCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UploadVacuumTruckServiceCommand request, CancellationToken cancellationToken)
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
                Id = VacuumTruckServicesId,
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
                ServiceId = VacuumTruckServicesId
            };

            await _context.DocumentServices.AddAsync(documentService, cancellationToken);
        }

        private async Task AddDocumentServiceIndividualFieldsAsync(CancellationToken cancellationToken)
        {
            var fields = new List<FieldService>
            {
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.День,
                    BookMarkName = "День",
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.Месяц,
                    BookMarkName = "Месяц",
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.Год,
                    BookMarkName = "Год"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ФИО,
                    BookMarkName = "ФизическоеЛицо"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ПаспортСерия,
                    BookMarkName = "ПаспортСерия"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ПаспортНомер,
                    BookMarkName = "ПаспортНомер"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ПаспортВыдан,
                    BookMarkName = "ПаспортВыдан"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ПаспортДатаВыдачи,
                    BookMarkName = "ПаспортДатаВыдачи"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.АдресТерритории,
                    BookMarkName = "АдресТерритории"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ПаспортКП,
                    BookMarkName = "КП"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.АдресРегистрации,
                    BookMarkName = "АдресРегистрации"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ЦенаЧисло,
                    BookMarkName = "ЦенаЧисло"
                },
                new()
                {
                    FieldTypeId = VacuumTruckServiceFieldsTypeEnum.ЦенаСтрока,
                    BookMarkName = "ЦенаСтрока"
                }
            };

            fields.ForAll(field => field.DocumentServiceId = VacuumTruckServicesId);

            await _context.FieldServices.AddRangeAsync(fields, cancellationToken);
        }
    }
}