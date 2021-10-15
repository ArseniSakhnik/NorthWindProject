using System.Collections.Generic;
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
        public List<ServiceProp> ServiceProps { get; set; }
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
            var service = new Service
            {
                ServiceProps = request.ServiceProps
            };
            await _context.Services.AddAsync(service, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}