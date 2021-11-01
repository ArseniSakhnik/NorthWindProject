using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.Service;

namespace NorthWindProject.Application.Features.Services.Commands
{
    public class CreateServiceCommand : IRequest
    {
        //TODO добавить возможность создания ServiceView
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ServicePropDto> ServicePropsDtoList { get; set; }
    }

    public class ServicePropDto
    {
        public ServicePropTypeEnum ServicePropTypeId { get; set; }
        public List<PermissibleValue> PermissibleValues { get; set; }
        public string Name { get; set; }
    }

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly AppDbContext _context;

        public CreateServiceCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var servicePropList = request.ServicePropsDtoList.Select(serviceProp => new ServiceProp
            {
                Name = serviceProp.Name,
                PermissibleValues = serviceProp.PermissibleValues,
                ServicePropTypeId = serviceProp.ServicePropTypeId
            }).ToList();

            var service = new Service
            {
                Name = request.Name,
                Description = request.Description,
                ServiceProps = servicePropList
            };

            await _context.Services.AddAsync(service, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}