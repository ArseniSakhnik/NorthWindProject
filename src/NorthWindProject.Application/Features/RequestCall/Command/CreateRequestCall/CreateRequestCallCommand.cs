using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.Common;
using NorthWind.Core.Interfaces;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.RequestCall.Command.CreateRequestCall
{
    public class CreateRequestCallCommand : IRequest
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }

    public class CreateRequestCallCommandHandler : IRequestHandler<CreateRequestCallCommand>
    {
        private readonly AppDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public CreateRequestCallCommandHandler(AppDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Unit> Handle(CreateRequestCallCommand request, CancellationToken cancellationToken)
        {
            var requestCall = new NorthWind.Core.Entities.RequestCall.RequestCall
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Comment = request.Comment
            };


            AuditableEntityFill(requestCall);
            await _context.RequestCalls.AddAsync(requestCall, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void AuditableEntityFill(AuditableEntity contract)
        {
            contract.CreatedByUsername = _currentUserService.UserName;
            contract.CreatedByUserId = _currentUserService.UserId == 0
                ? null
                : _currentUserService.UserId;
            contract.Created = DateTime.Now;
        }
    }
}