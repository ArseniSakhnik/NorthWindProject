using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWind.Core.Entities.RequestCall;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Services.BotService;

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
        private readonly BotService _botService;

        public CreateRequestCallCommandHandler(AppDbContext context, BotService botService)
        {
            _context = context;
            _botService = botService;
        }


        public async Task<Unit> Handle(CreateRequestCallCommand request, CancellationToken cancellationToken)
        {
            var sendRequestCallDto = new SendRequestCallDto
            {
                name = request.Name,
                text_data = request.Comment,
                number = request.PhoneNumber,
            };

            var succeed = await _botService.SendRequestCall(sendRequestCallDto);

            if (succeed) return Unit.Value;
            
            
            var failedRequestCall = new FailedRequestCall
            {
                Name = request.Name,
                Comment = request.Comment,
                PhoneNumber = request.PhoneNumber
            };

            await _context.FailedRequestCalls.AddAsync(failedRequestCall, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}