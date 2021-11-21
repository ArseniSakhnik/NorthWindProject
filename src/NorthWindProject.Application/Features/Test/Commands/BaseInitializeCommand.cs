

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Entities.DocumentTemplate;

namespace NorthWindProject.Application.Features.Test.Commands
{
    public class BaseInitializeCommand : IRequest
    {
        public IFormFile File { get; set; }
    }
    
    public class BaseInitializeCommandHandler : IRequestHandler<BaseInitializeCommand>
    {
        private readonly AppDbContext _context;
        
        public BaseInitializeCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(BaseInitializeCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}