using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;

namespace NorthWindProject.Application.Features.RequestCall.Command.SendUnsetRequestCalls
{
    public class SendUnsetRequestCallsCommand : IRequest
    {
        
    }
    
    public class SendUnsetRequestCallsCommandHandler : IRequestHandler<SendUnsetRequestCallsCommand>
    {
        private readonly AppDbContext _context;

        public SendUnsetRequestCallsCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SendUnsetRequestCallsCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}