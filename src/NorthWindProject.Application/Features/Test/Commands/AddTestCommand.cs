using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NorthWindProject.Application.Common.Access;
using NorthWindProject.Application.Features.Test.Events;

namespace NorthWindProject.Application.Features.Test.Commands
{
    public class AddTestCommand : IRequest
    {
        public string Name { get; set; }
    }

    public class AddTestCommandHandler : IRequestHandler<AddTestCommand>
    {
        private readonly AppDbContext _context;
        
        public AddTestCommandHandler(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(AddTestCommand request, CancellationToken cancellationToken)
        {
            var test = new Core.Entities.Test
            {
                Name = request.Name
            };
            test.DomainEvents.Add(new AddTestEvent(0));

            await _context.Tests.AddAsync(test, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}